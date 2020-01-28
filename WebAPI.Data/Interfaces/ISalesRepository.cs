using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.ViewModels;

namespace WebAPI.Data.Interfaces
{
    public interface ISalesRepository
    {

        Task<List<TotalMonthsModel>> TotalSaleS();
     
    }
}
