using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public static class DBService
    {
        public static List<Invoice> GetAllInvoices()
        {
            // TODO implement getting invoices
            List<Invoice> invoices = new List<Invoice>();
            for(int i = 0; i < 10; i++)
            {
                Invoice invoice = new Invoice();
            }

            return invoices;
        }

        public static void InsertInvoice(Invoice invoice)
        {
            // TODO implement insertint data
            ;
        }
    }
}
