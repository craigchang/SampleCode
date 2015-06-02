using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Domain
{
    /// <summary>
    /// An example domain object with a one-to-one mapping with Person class
    /// </summary>
    public class Employee
    {
        public Employee()
        {
            SetPerson(new Person());
        }

        protected internal virtual void SetPerson(Person current)
        {
            Person = current;
            if (current != null)
                Person.SetEmployee(this);
        }

        public virtual Person Person { get; protected set; }

        public virtual Guid Id { get; set; }
        public virtual string Role { get; set; }

        
    }
}
