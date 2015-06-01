using NHibernate;
using NHibernateTutorial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(Employee employee)
        {

        }
        public void Update(Employee employee)
        {

        }
        public void Remove(Employee employee)
        {

        }
        public Employee GetById(Guid employeeId)
        {
            return null;
        }
        public Employee GetByName(string name)
        {
            return null;
        }
    }
}
