using Estoque.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Infra.Data
{
    public class UnitOfWork(SQLContext context,
                            ILogger<UnitOfWork> logger) : IUnitOfWork
    {

        public bool SaveChanges()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"An error occurred and the database could not be updated, error: {ex.Message}", ex);
                return false;
            }
        }
    }
}
