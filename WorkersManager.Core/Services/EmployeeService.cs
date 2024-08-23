using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManager.Core.Models;
using WorkersManager.Core.Repositories;

namespace WorkersManager.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDB _employeeDB;
        
        public EmployeeService (IEmployeeDB employeeDB)
        {
            _employeeDB = employeeDB;
        }

        public async Task AddOfficeEmployee(OfficeEmployee employee)
        {
            await _employeeDB.AddOfficeEmployee(employee);
        }

        public async Task AddProductionEmployee(ProductionEmployee employee)
        {
            await _employeeDB.AddProductionEmployee(employee);
        }

        public async Task<List<OfficeEmployee>> GetAllOfficeEmployees()
        {
            return await _employeeDB.GetAllOfficeEmployees();
        }

        public async Task<List<ProductionEmployee>> GetAllProductionEmployees()
        {
            return await _employeeDB.GetAllProductionEmployees();
        }

        public async Task ModifyOfficeEmployee(OfficeEmployee employee)
        {
            await _employeeDB.ModifyOfficeEmployee(employee);
        }

        public async Task ModifyingProductionEmployee(ProductionEmployee employee)
        {
            await _employeeDB.ModifyingProductionEmployee(employee);
        }

        public async Task DeleteOfficeEmployee(int id)
        {
            await _employeeDB.DeleteOfficeEmployee(id);
        }

        public async Task DeleteProductionEmployee(int id)
        {
            await _employeeDB.DeleteProductionEmployee(id);
        }
    }

    public interface IEmployeeService
    {
        Task AddOfficeEmployee(OfficeEmployee employee);
        Task AddProductionEmployee(ProductionEmployee employee);
        Task<List<OfficeEmployee>> GetAllOfficeEmployees();
        Task<List<ProductionEmployee>> GetAllProductionEmployees();
        Task ModifyOfficeEmployee(OfficeEmployee employee);
        Task ModifyingProductionEmployee(ProductionEmployee employee);
        Task DeleteOfficeEmployee(int id);
        Task DeleteProductionEmployee(int id);
    }
}
