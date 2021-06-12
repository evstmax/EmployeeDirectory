using EmployeeDirectory.IRepository;
using System;
using System.Threading.Tasks;
using EmployeeDirectory.Data;

namespace EmployeeDirectory.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Department> _department;
        private IGenericRepository<Position> _position;
        private IGenericRepository<Employee> _employee;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Department> Departments => _department ??= new GenericRepository<Department>(_context);
        public IGenericRepository<Position> Positions => _position ??= new GenericRepository<Position>(_context);
        public IGenericRepository<Employee> Employees => _employee ??= new GenericRepository<Employee>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}