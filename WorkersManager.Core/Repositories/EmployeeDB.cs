using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManager.Core.Models;

namespace WorkersManager.Core.Repositories
{
    public class EmployeeDB : IEmployeeDB
    {
        private readonly IMongoCollection<OfficeEmployee> _officeStaff;
        private readonly IMongoCollection<ProductionEmployee> _productionStaff;

        public EmployeeDB(IMongoClient mongoClient)
        {
            _officeStaff = mongoClient.GetDatabase("officeStaff").GetCollection<OfficeEmployee>("officeEmployees_cache");
            _productionStaff = mongoClient.GetDatabase("productionStaff").GetCollection<ProductionEmployee>("productionEmployees_cache");
        }

        public async Task AddOfficeEmployee(OfficeEmployee employee)
        {
            await _officeStaff.InsertOneAsync(employee);
        }

        public async Task AddProductionEmployee(ProductionEmployee employee)
        {
            await _productionStaff.InsertOneAsync(employee);
        }

        public async Task<List<OfficeEmployee>> GetAllOfficeEmployees()
        {
            return await _officeStaff.Find(_ => true).ToListAsync();
        }

        public async Task<List<ProductionEmployee>> GetAllProductionEmployees()
        {
            return await _productionStaff.Find(_ => true).ToListAsync();
        }

        public async Task ModifyOfficeEmployee(OfficeEmployee employee)
        {
            var filter = Builders<OfficeEmployee>.Filter.Eq(x => x.Id, employee.Id);
            var result = await _officeStaff.ReplaceOneAsync(filter, employee);

            if (result.MatchedCount == 0)
            {
                throw new Exception($"No office employee found with id: {employee.Id}");
            }
        }

        public async Task ModifyingProductionEmployee(ProductionEmployee employee)
        {
            var filter = Builders<ProductionEmployee>.Filter.Eq(x => x.Id, employee.Id);
            var result = await _productionStaff.ReplaceOneAsync(filter, employee);

            if (result.ModifiedCount == 0)
            {
                throw new Exception($"No production employee found with id: {employee.Id}");
            }
        }

        public async Task DeleteOfficeEmployee(int id)
        {
            var filter = Builders<OfficeEmployee>.Filter.Eq(x => x.Id, id);
            var result = await _officeStaff.DeleteOneAsync(filter);
        }

        public async Task DeleteProductionEmployee(int id)
        {
            var filter = Builders<ProductionEmployee>.Filter.Eq(x => x.Id, id);
            var result = await _productionStaff.DeleteOneAsync(filter);
        }
    }

    public interface IEmployeeDB
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
