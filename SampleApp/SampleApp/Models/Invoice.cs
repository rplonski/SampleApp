using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models
{
    public class Invoice
    {
        public Invoice()
        {
            Guid guid;
            guid = Guid.NewGuid();
            Id = guid.ToString();
            FilePath = ConfigurationManager.AppSettings["InvoiceFilePath"] + Id.ToString() + ".xml";
            items = new List<InvoiceItem>();
        }

        public string Id { get; set; }

        public double TotalGrossAmount { get; set; }
        public double TotalNetAmount { get; set; }

        public string SellerData { get; set; }
        public string BuyerData { get; set; }
        public DateTime? IssueDate { get; set; }

        Company company { get; set; }
        public List<InvoiceItem> items { get; set; }

        private string FilePath { get; set; }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public string GetFilePath()
        {
            return FilePath;
        }

        public void SaveFile()
        {
            InvoiceFileService.SaveInvoiceFile(this);
        }

        public void CalculateTotalNetAmount()
        {
            double totalNetAmount = 0;

            foreach(var invoiceItem in items)
            {
                totalNetAmount += invoiceItem.AmountNet;
            }

            this.TotalNetAmount = totalNetAmount;
        }

        public void CalculateTotalGrossAmount()
        {
            double totalGrossAmount = 0;

            foreach (var invoiceItem in items)
            {
                totalGrossAmount += invoiceItem.AmountGross;
            }

            this.TotalGrossAmount = totalGrossAmount;
        }
    }
}
