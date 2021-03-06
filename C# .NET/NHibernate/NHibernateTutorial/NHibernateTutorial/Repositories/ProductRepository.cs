﻿using NHibernate;
using NHibernate.Criterion;
using NHibernateTutorial.Domain;
using NHibernateTutorial.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Product[] _products = new[]
        {
            new Product {Name = "Melon", Category = "Fruits"},
            new Product {Name = "Pear", Category = "Fruits"},
            new Product {Name = "Milk", Category = "Beverages"},
            new Product {Name = "Coca Cola", Category = "Beverages"},
            new Product {Name = "Pepsi Cola", Category = "Beverages"},
        };

        public void CreateInitialData()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (var product in _products)
                        session.Save(product);
                    transaction.Commit();
                }
            }
        }

        public void Add(Product product)
        {
            /* using "using" will properly dispose session after use */
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(product);
                    transaction.Commit();
                }
            }
        }

        public void Update(Product product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(product);
                    transaction.Commit();
                }
            }
        }

        public void Remove(Product product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(product);
                    transaction.Commit();
                }
            }
        }

        public Product GetById(Guid productId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Product>(productId);
            }
        }

        public Product GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Product product = session
                    .CreateCriteria(typeof(Product))
                    .Add(Restrictions.Eq("Name", name))
                    .UniqueResult<Product>();
                return product;
            }
        }

        public ICollection<Product> GetByCategory(string category)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var products = session
                    .CreateCriteria(typeof(Product))
                    .Add(Restrictions.Eq("Category", category))
                    .List<Product>();
                return products;
            }
        }
    }
}
