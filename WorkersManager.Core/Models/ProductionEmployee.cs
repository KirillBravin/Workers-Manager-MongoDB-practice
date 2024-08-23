using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersManager.Core.Models
{
    public class ProductionEmployee : Employee
    {
        [BsonId]
        public int Id { get; set; }
        public string Shift { get; set; }

        public ProductionEmployee(string firstName, string lastName, int age, string shift) : base(firstName, lastName, age)
        {
            Shift = shift;
        }
    }
}
