using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Services
{
    public class SalesRecordService 
    {
        private readonly SaleWebMvcContext _context;

        public SalesRecordService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public async Task<IList<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)       
                result = result.Where(x => x.Data >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(x => x.Data <= maxDate.Value);

            return await result.Include(x => x.Seller)
                               .Include(x => x.Seller.Department)
                               .OrderByDescending(x => x.Data)
                               .ToListAsync();
        }

        public async Task<IList<IGrouping<Department,SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
                result = result.Where(x => x.Data >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(x => x.Data <= maxDate.Value);

            return await result.Include(x => x.Seller)
                               .Include(x => x.Seller.Department)
                               .OrderByDescending(x => x.Data)
                               .GroupBy(x => x.Seller.Department)
                               .ToListAsync();
        }

    }
}
