using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models
{
    public class InvoiceItem
    {
        public InvoiceItem()
        {
            Guid guid;
            guid = Guid.NewGuid();
            Id = guid.ToString();

        }

        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public string Name { get; set; }
        private int VatRate { get; set; }
        public double AmountNet { get; set; }
        public double AmountGross { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }

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
            else throw new ArgumentOutOfRangeException("Wrong vat rate value");
        }

        public void SetAmountNet(double amountNet)
        {
            AmountNet = amountNet;
        }

        public int GetVatRate()
        {
            return VatRate;
        }

    }
}
