using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models
{
    public class InvoiceItem
    {
        public string Name { get; set; }
        private int VatRate { get; set; }
        public double AmountNet { get; set; }
        private double AmountGross { get; set; }

        public void CalculateGrossAmount()
        {
            AmountGross = AmountNet + AmountNet * ((double)VatRate / 100);
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetVatRate(int vatRate)
        {
            if (vatRate >= 0 && vatRate <= 100)
            {
                VatRate = vatRate;
            }
            else throw new Exception("Wrong vat rate value");
        }

        public void SetAmountNet(double amountNet)
        {
            AmountNet = amountNet;
        }

    }
}
