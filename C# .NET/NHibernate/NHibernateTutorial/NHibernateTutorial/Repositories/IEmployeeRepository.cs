using NHibernateTutorial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);
        Employee GetById(Guid employeeId);
        Employee GetByName(string name);
    }
}
