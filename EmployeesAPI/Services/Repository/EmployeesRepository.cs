using EmployeesAPI.Data;
using EmployeesAPI.Data.Exceptions;
using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Services.Repository
{
    /// <summary>
    /// Репозиторий сотрудников
    /// </summary>
    public class EmployeesRepository(AppDbContext dbContext) : IEmployeesRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task CreateAsync(EmployeeModel employee)
        {
            await ThrowIfExistsAsync(employee.Name);

            try
            {
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException exc)
            {
                throw new CreationFailedException(exc);
            }
        }

        private async Task ThrowIfExistsAsync(string employeeName)
        {
            var exists = await _dbContext.Employees.AnyAsync(x => x.Name.Equals(employeeName));
			if (exists)
                throw new AlreadyExistsException();
        }

        public async Task<EmployeeModel> GetAsync(string employeeName)
        {
            return await FindByNameAsync(employeeName);
        }

        private async Task<EmployeeModel> FindByNameAsync(string employeeName)
        {
			return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Name.Equals(employeeName))
						 ?? throw new NotFoundException();
		}

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task UpdateAsync(EmployeeModel employee)
        {
            try
            {
                var entity = await FindByNameAsync(employee.Name);
                CopyEmployeeData(employee, entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException exc)
            {
                throw new UpdateFailedException(exc);
            }
        }

        private void CopyEmployeeData(EmployeeModel from, EmployeeModel to)
        {
            to.Age = from.Age;
            to.Position = from.Position;
            to.Salary = from.Salary;
            to.EmployeedDate = from.EmployeedDate;
        }

        public async Task DeleteAsync(string employeeName)
        {
            try
            {
                var entity = await FindByNameAsync(employeeName);
                _dbContext.Employees.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException exc)
            {
                throw new DeleteFailedException(exc);
            }
        }
    }
}
