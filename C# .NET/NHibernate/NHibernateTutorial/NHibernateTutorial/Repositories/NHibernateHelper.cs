﻿using NHibernate;
using NHibernate.Cfg;
using NHibernateTutorial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Repositories
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    //configuration.AddAssembly(typeof(Product).Assembly);
                    configuration.AddAssembly("NHibernateTutorial");
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

    }
}
