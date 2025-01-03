using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Infra.Data.Repositories
{
    public class InventoryMovimentationRepository : IInventoryMovimentationRepository
    {
        protected readonly SQLContext SqlContext;
        protected readonly DbSet<InventoryMovimentation> DbSet;

        public InventoryMovimentationRepository(SQLContext sqlContext)
        {
            SqlContext = sqlContext;
            DbSet = sqlContext.Set<InventoryMovimentation>();
        }

        public double GetTotalByProductId(long productId)
        {
            double totalInc = DbSet.Where(x => x.ProductId == productId && x.Inc).Sum(x => x.Quantity);
            double totalNotInc = DbSet.Where(x => x.ProductId == productId && !x.Inc).Sum(x => x.Quantity);
            return totalInc - totalNotInc;
        }

        public void Insert(InventoryMovimentation movimentation)
        {
            DbSet.Add(movimentation);
        }
    }
}
