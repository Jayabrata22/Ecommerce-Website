using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Implementation
{
    public  class TypeListSpecification: BaseSpecificRepository<Product ,string>
    {
        public TypeListSpecification()
        {
            AddSelect(x=> x.Type);
            ApplyDistinct();
        }
    }
}
