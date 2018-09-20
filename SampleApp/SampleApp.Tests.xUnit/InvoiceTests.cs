using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleApp.Tests.xUnit
{
    public class InvoiceTests
    {
        [Fact]
        public void SetFilePath_CorrectPathParameter_CorrectFilePath()
        {
            //Arrange
            var invoice = new Invoice();
            string filePath = @"C:\Invoices";

            //Act
            invoice.SetFilePath(filePath);

            //Assert
            Assert.Equal(filePath, invoice.GetFilePath());
        }

        [Fact]
        public void CalculateTotalGrossAmount_CorrectValues_CorrectTotalGrossAmount()
        {
            //Arrange
            var invoice = new Invoice();
            for (int i = 0; i < 1; i++)
            {
                var invoiceItem = new InvoiceItem()
                {
                    AmountNet = 100,
                    Amount = 1
                };
                invoiceItem.SetVatRate(23);
                invoiceItem.CalculateGrossAmount();

                invoice.items.Add(invoiceItem);
            }

            //Act
            invoice.CalculateTotalGrossAmount();

            //Assert
            Assert.Equal(123, invoice.TotalGrossAmount);
        }

        [Fact]
        public void CalculateTotalGrossAmount_CorrectValuesFiveItems_CorrectTotalGrossAmount()
        {
            //Arrange
            var invoice = new Invoice();
            for (int i = 0; i < 5; i++)
            {
                var invoiceItem = new InvoiceItem()
                {
                    AmountNet = 100,
                    Amount = 1
                };
                invoiceItem.SetVatRate(23);
                invoiceItem.CalculateGrossAmount();

                invoice.items.Add(invoiceItem);
            }

            //Act
            invoice.CalculateTotalGrossAmount();

            //Assert
            Assert.Equal(615, invoice.TotalGrossAmount);
        }


        [Fact]
        public void CalculateTotalNetAmount_CorrectValues_CorrectTotalNetAmount()
        {
            //Arrange
            var invoice = new Invoice();
            for (int i = 0; i < 5; i++)
            {
                var invoiceItem = new InvoiceItem()
                {
                    AmountNet = 100,
                    Amount = 1
                };

                invoice.items.Add(invoiceItem);
            }

            //Act
            invoice.CalculateTotalNetAmount();

            //Assert
            Assert.Equal(500, invoice.TotalNetAmount);
        }
    }
}
