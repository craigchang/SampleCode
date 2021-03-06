﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Domain
{
    /// <summary>
    /// An example domain object with a one-to-one mapping with Employee class
    /// </summary>
    public class Person
    {
        protected internal virtual void SetEmployee(Employee current)
        {
            Employee = current;
        }

        public virtual Employee Employee { get; protected set; }

        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
