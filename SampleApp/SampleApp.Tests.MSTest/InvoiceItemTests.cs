using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp.Models;

namespace SampleApp.Tests.MSTest
{
    [TestClass]
    public class InvoiceItemTests
    {
        [TestMethod]
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

        [TestMethod]
        public void CalculateGrossAmount_IncorrectVat_IncorrectFrossAmount()
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

        [TestMethod]
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

        [TestMethod]
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
            catch(Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
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
