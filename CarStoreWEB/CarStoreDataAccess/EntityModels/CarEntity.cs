using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreDataAccess.EntityModels
{
    public class CarEntity
    {
        //Car structure
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Model { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
