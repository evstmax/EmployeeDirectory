using System;
using System.Threading.Tasks;
using EmployeeDirectory.Data;

namespace EmployeeDirectory.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Department> Departments { get; }
        IGenericRepository<Position> Positions { get; }
        IGenericRepository<Employee> Employees { get; }
        Task Save();
    }
}