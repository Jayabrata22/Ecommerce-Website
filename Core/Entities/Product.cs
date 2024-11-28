using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        //public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public required string Type {  get; set; }
        public required string PictureUrl { get; set; }
        public required string Brand {  get; set; }
    }
}
