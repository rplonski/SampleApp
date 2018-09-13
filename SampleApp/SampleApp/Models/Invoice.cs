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
            Id = new Guid();
            FilePath = ConfigurationManager.AppSettings["InvoiceFilePath"] + Id.ToString() + ".xml";
        }

        public Guid Id { get; set; }

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
    }
}
