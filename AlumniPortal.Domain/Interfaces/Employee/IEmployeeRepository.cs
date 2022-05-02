using AlumniPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.Domain.Interfaces.Employee
{
    public interface IEmployeeRepository:IRepository<AlumniPersonalDetails>
    {
         Task<IEnumerable<AlumniPersonalDetails>> GetEmployees(int count);
    }
}
