using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersManager.Core.Models
{
    public class OfficeEmployee : Employee
    {
        [BsonId]
        public int Id { get; set; }
        public string Department { get; set; }

        public OfficeEmployee(string firstName, string lastName, int age, string department) : base (firstName, lastName, age)
        {
            Department = department;
        }
    }
}
