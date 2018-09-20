using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Tests.MSTest
{
    [TestClass]
    public class InvoiceTests
    {
        [TestMethod]
        public void SetFilePath_CorrectPathParameter_CorrectFilePath()
        {
            //Arrange
            var invoice = new Invoice();
            string filePath = @"C:\Invoices";

            //Act
            invoice.SetFilePath(filePath);

            //Assert
            Assert.AreEqual(invoice.GetFilePath(), filePath);
        }

        [TestMethod]
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
            Assert.AreEqual(invoice.TotalGrossAmount, 123);
        }

        [TestMethod]
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
            Assert.AreEqual(invoice.TotalGrossAmount, 615);
        }


        [TestMethod]
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
            Assert.AreEqual(invoice.TotalNetAmount, 500);
        }
    }
}
