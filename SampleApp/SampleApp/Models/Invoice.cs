using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models
{
    public class Invoice
    {
        public Invoice()
        {

        }

        Company company { get; set; }
        public List<InvoiceItem> items { get; set; }
    }
}
