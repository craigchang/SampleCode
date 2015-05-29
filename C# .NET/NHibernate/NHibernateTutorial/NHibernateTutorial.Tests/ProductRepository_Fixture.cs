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
    public class ProductRepository_Fixture
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        [TestMethod]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Product).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [TestMethod]
        public void Can_add_new_product()
        {
            var product = new Product { Name = "Apple", Category = "Fruits", Discontinued = false };
            IProductRepository repository = new ProductRepository();
            repository.Add(product);
        }
    }
}
