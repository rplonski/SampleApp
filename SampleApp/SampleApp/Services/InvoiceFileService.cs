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
            string filePath = invoice.GetFilePath();
            string fileContent = string.Empty;

            fileContent += invoice.SellerData + invoice.BuyerData + invoice.IssueDate.ToString();

            
            //foreach (var invoiceItem in invoice.items)
            //{
            //    fileContent += invoiceItem.Name;
            //}

            using (FileStream fs = File.Create(filePath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(fileContent);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }


        }

        public static void DownloadInvoiceFile(string invoiceId, string sourceFilePath, string downloadingFilePath)
        {
            if (!File.Exists(sourceFilePath))
                throw new FileNotFoundException();
            File.Copy(sourceFilePath, downloadingFilePath, true);
     
        }
    }
}
