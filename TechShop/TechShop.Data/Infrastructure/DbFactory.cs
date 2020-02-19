using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        TechShopDbContext TechShopDbContext;
        public TechShopDbContext Init()
        {
            return TechShopDbContext ?? (TechShopDbContext = new TechShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (TechShopDbContext != null)
            {
                TechShopDbContext.Dispose();
            }
        }
    }
}
