using SaleWebMvc.Models;
using SaleWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Data
{
    public class SeedingServices
    {
        private SaleWebMvcContext _context;

        public SeedingServices(SaleWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // Bd ja foi populada
            }

            Department d1 = new Department("Computers");
            Department d2 = new Department("Electronics");
            Department d3 = new Department("Fashion");
            Department d4 = new Department("Books");

            Seller s1 = new Seller("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 1500.0, d2);
            Seller s3 = new Seller("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2000.0, d3);
            Seller s4 = new Seller("Marta Red", "marta@gmail.com", new DateTime(1993, 11, 30), 2500.0, d4);
            Seller s5 = new Seller("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 3000.0, d1);
            Seller s6 = new Seller("AlexPink", "alexpink@gmail.com", new DateTime(1997, 3, 4), 2000.0, d2);

            SalesRecord r1 = new SalesRecord(new DateTime(2018,09,25), 11000.0,SaleStatus.Billed,s1);
            SalesRecord r2 = new SalesRecord(new DateTime(2019, 05, 02), 7000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(new DateTime(2020, 09, 05), 5000.0, SaleStatus.Canceled, s3);
            SalesRecord r4 = new SalesRecord(new DateTime(2015, 02, 15), 20000.0, SaleStatus.Canceled, s4);
            SalesRecord r5 = new SalesRecord(new DateTime(2016, 04, 04), 50000.0, SaleStatus.Pending, s5);
            SalesRecord r6 = new SalesRecord(new DateTime(2017, 03, 20), 15000.0, SaleStatus.Billed, s6);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6);

            _context.SaveChanges();
        }
    }
}
