using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models
{
    public class InvoiceItem
    {
        public int VatRate { get; set; }
        public double AmountNet { get; set; }
        public double AmountGross { get; set; }
    }
}
