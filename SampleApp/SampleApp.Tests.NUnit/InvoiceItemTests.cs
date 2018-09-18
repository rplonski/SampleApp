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
        public void CalculateGrossAmount_CorrectVat_CorrectGrossAmount()
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

        [Test]
        public void CalculateGrossAmount_IncorrectVat_IncorrectGrossAmount()
        {
            //Arrange
            var invoiceItem = new InvoiceItem();
            int vatParamter = 120;
            Exception expectedException = null;

            //Act
            try
            {
                invoiceItem.SetVatRate(vatParamter);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.AreNotEqual(vatParamter, invoiceItem.GetVatRate());
        }

        [Test]
        public void SetVatRate_CorrectVatParameter_CorrectVatValue()
        {
            //Arrange
            var invoiceItem = new InvoiceItem();
            int vatParamter = 23;

            //Act
            invoiceItem.SetVatRate(vatParamter);

            //Assert
            Assert.AreEqual(invoiceItem.GetVatRate(), vatParamter);
        }

        [Test]
        public void SetVatRate_IncorrectVatParameter_ExceptionOccured()
        {
            //Arrange
            var invoiceItem = new InvoiceItem();
            int vatParamter = 120;
            Exception expectedException = null;

            //Act
            try
            {
                invoiceItem.SetVatRate(vatParamter);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNotNull(expectedException);
        }

        [Test]
        public void SetVatRate_IncorrectVatParameter_CorrectExceptionType()
        {
            //Arrange
            var invoiceItem = new InvoiceItem();
            int vatParamter = 120;
            Exception expectedException = null;
            var argumentOutOfRangeException = new ArgumentOutOfRangeException();

            //Act
            try
            {
                invoiceItem.SetVatRate(vatParamter);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.AreEqual(argumentOutOfRangeException.GetType(), expectedException.GetType());
        }
    }
}
