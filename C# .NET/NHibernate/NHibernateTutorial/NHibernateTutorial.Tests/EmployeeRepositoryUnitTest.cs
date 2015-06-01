using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernateTutorial.Domain;
using NHibernateTutorial.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Tests
{
    [TestClass]
    public class EmployeeRepositoryUnitTest
    {
        /// <summary>
        /// Test one-to-one mapping
        /// </summary>
        [TestMethod]
        public void AddEmployeeAndPersonTest()
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                Employee employee = new Employee();
                employee.Role = "Manager";
                employee.Person.FirstName = "FirstName";
                employee.Person.LastName = "LastName";

                session.Save(employee);
                session.Save(employee.Person);

                tx.Commit();
            }

        }
    }
}
