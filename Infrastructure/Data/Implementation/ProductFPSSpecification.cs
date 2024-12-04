using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Implementation
{
    public class ProductFPSSpecification : BaseSpecificRepository<Product>
    {
        public ProductFPSSpecification(string? brand, string? type, string? sort) : base(x =>
        (string.IsNullOrEmpty(brand) || x.Brand == brand) &&
        (string.IsNullOrWhiteSpace(type) || x.Type == type)
        )
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderby(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderbyDesc(x => x.Price); break;
                default:
                    AddOrderby(x => x.ProductName);
                    break;
                    
            }
        }
    }
}
