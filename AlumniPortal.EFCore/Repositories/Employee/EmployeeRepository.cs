using AlumniPortal.Domain.Entities;
using AlumniPortal.Domain.Interfaces.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.EFCore.Repositories.Employee
{
    public class EmployeeRepository : Repository<AlumniPersonalDetails>, IEmployeeRepository
    {
        public EmployeeRepository(APContext _context):base(_context)
        {

        }
        public async Task<IEnumerable<AlumniPersonalDetails>> GetEmployees(int count)
        {
            return  await _context.AlumniPersonalDetails.Take(count).ToListAsync();
        }

    }
}
