﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrendITech.Core.Entities;
using TrendITech.Core.Repository.Interface.Base;

namespace TrendITech.Core.Repository.Interface
{
    public interface IProductsRepository : IBaseRepository<Products>
    {
        Products GetByModelNo(string modelNo);
        Products GetBySku(string sku);
        IEnumerable<Products> GetByCategory(Category category);
    }
}
