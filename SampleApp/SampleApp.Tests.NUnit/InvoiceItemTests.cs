using NUnit.Framework;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Tests.NUnit
{
    [TestFixture]
    public class InvoiceItemTests
    {
        [Test]
        public void CalculateGrossAmount_CorrectVat_CorrectFrossAmount()
        {
            //Arrange
            var invoiceItem = new InvoiceItem();
            invoiceItem.AmountNet = 100;
            invoiceItem.SetVatRate(23);

            //Act
            invoiceItem.CalculateGrossAmount();

            //Assert
            Assert.AreEqual(invoiceItem.AmountGross, 123);
        }
    }
}
