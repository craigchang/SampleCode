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
    public class NHibernateConfigUnitTest
    {
        [TestMethod]
        public void GenerateSchemaTest()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            //new SchemaExport(cfg).Execute(false, true, false, false);
        }
    }
}
