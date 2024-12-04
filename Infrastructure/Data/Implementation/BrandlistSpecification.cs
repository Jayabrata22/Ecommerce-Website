using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Implementation
{
    public class BrandlistSpecification : BaseSpecificRepository<Product,string>
    {

        public BrandlistSpecification()
        {
            AddSelect(x => x.Brand);
            ApplyDistinct();
        }
    }
}
