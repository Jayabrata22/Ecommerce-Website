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
        public ProductFPSSpecification(ProductSpecParams specParams) : base(x =>
        (string.IsNullOrEmpty(specParams.Search) || x.ProductName.ToLower().Contains(specParams.Search)) &&
        (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand) &&
        (specParams.Types.Count == 0 || specParams.Brands.Contains(x.Type))
        ))
        {
            ApplyPaging(specParams.PageSize *(specParams.PageIndex -1),specParams.PageSize);
            switch (specParams.Sort)
            {
                case "priceAsc":
                    AddOrderby(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderbyDesc(x => x.Price); 
                    break;
                default:
                    AddOrderby(x => x.ProductName);
                    break;
                    
            }
        }
    }
}
