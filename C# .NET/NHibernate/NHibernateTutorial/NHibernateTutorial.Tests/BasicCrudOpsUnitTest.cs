using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernateTutorial.Domain;
using NHibernateTutorial.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Tests
{
    [TestClass]
    public class BasicCrudOpsUnitTest
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;
        private readonly Product[] _products = new[]
        {
            new Product {Name = "Melon", Category = "Fruits"},
            new Product {Name = "Pear", Category = "Fruits"},
            new Product {Name = "Milk", Category = "Beverages"},
            new Product {Name = "Coca Cola", Category = "Beverages"},
            new Product {Name = "Pepsi Cola", Category = "Beverages"},
        };

        [TestMethod]
        public void SetUpConfigTest()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Product).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [TestMethod]
        public void InitializeProductDataTest()
        {
            IProductRepository repository = new ProductRepository();
            repository.CreateInitialData();
        }

        [TestMethod]
        public void AddNewProductTest()
        {
            var product = new Product { Name = "Apple", Category = "Fruits", Discontinued = false };
            IProductRepository repository = new ProductRepository();
            repository.Add(product);

            // use session to try to load the product
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                // Test that the product was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(product, fromDb);
                Assert.AreEqual(product.Name, fromDb.Name);
                Assert.AreEqual(product.Category, fromDb.Category);
            }
        }

        [TestMethod]
        public void UpdateExistingProductTest()
        {
            IProductRepository repository = new ProductRepository();
            var product = repository.GetById(new Guid("FF0618C7-4332-4732-92CD-19FB59497220"));
            product.Name = "Yellow Pear";
            repository.Update(product);

            // use session to try to load the product
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                Assert.AreEqual(product.Name, fromDb.Name);
            }
        }

        [TestMethod]
        public void RemoveExistingProductTest()
        {
            IProductRepository repository = new ProductRepository();
            var product = repository.GetById(new Guid("FF0618C7-4332-4732-92CD-19FB59497220"));
            repository.Remove(product);

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                Assert.IsNull(fromDb);
            }
        }
        
        [TestMethod]
        public void GetExistingProductByNameTest()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetByName(_products[1].Name);

            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(_products[1], fromDb);
            Assert.AreEqual(_products[1].Id, fromDb.Id);
        }

        [TestMethod]
        public void GetExistingProductsByCategoryTest()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetByCategory("Fruits");

            Assert.AreEqual(3, fromDb.Count);
            Assert.IsTrue(IsInCollection(_products[0], fromDb));
            Assert.IsTrue(IsInCollection(_products[1], fromDb));
        }

        private bool IsInCollection(Product product, ICollection<Product> fromDb)
        {
            foreach (var item in fromDb)
                if (product.Id == item.Id)
                    return true;
            return false;
        }
    }
}
