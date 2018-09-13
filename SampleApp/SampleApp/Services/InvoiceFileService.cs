using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public static class InvoiceFileService
    {
        public static void SaveInvoiceFile(Invoice invoice)
        {
            //TODO: implement mechanism to save file
            // Temporary save fake file
            File.Create(invoice.GetFilePath());

           
        }
    }
}
