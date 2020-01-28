using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.ViewModels;
using WebAPI.Data.Context;
using WebAPI.Data.Interfaces;
using System.Linq;
using System.Globalization;

namespace WebAPI.Data.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<List<TotalMonthsModel>> TotalSaleS()
        {
            var result = await Task.Run(() => TotalSaleSNotAsync());
            return result;
        }
        public async Task<List<TotalMonthsModel>> TotalSaleSNotAsync()
        {
            var totalSales = (from f in _context.SalesOrderHeader
                                group f by new { month = f.OrderDate.Month, year = f.OrderDate.Year } into g
                                select new
                                {
                                    dt = string.Format("{0}/{1}", g.Key.month, g.Key.year),
                                    total = g.Count()
                                }).ToList();


            var TotalMonthsModel = totalSales.Select(x => new { Name = x, Sort = DateTime.ParseExact(x.dt, "M/yyyy", CultureInfo.InvariantCulture) })
            .OrderBy(x => x.Sort)
            .Select(x => x.Name);


            var TotalMonthsModel1 = (from p in TotalMonthsModel
                                     select new TotalMonthsModel
                                     {
                                         Month = p.dt,
                                         Total = p.total
                                     }).ToList();

            return TotalMonthsModel1;

        }
    }
}
