using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleApp.Tests.xUnit
{
    public class InvoiceItemTests
    {
        //[Fact]
        //public void CalculateGrossAmount_CorrectVat_CorrectFrossAmount()
        //{
        //    //Arrange
        //    var invoiceItem = new InvoiceItem();
        //    invoiceItem.AmountNet = 100;
        //    invoiceItem.SetVatRate(23);

        //    //Act
        //    invoiceItem.CalculateGrossAmount();

        //    //Assert
        //    Assert.Equal(123, invoiceItem.AmountGross);
        //}

        [Fact]
        public void CalculateGrossAmount_CorrectVat_CorrectGrossAmount()
        {
            //Arrange
            var invoiceItem = new InvoiceItem();
            invoiceItem.AmountNet = 100;
            invoiceItem.SetVatRate(23);

            //Act
            invoiceItem.CalculateGrossAmount();

            //Assert
            Assert.Equal(123, invoiceItem.AmountGross);
        }

        [Fact]
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
            Assert.NotEqual(vatParamter, invoiceItem.GetVatRate());
        }

        [Fact]
        public void SetVatRate_CorrectVatParameter_CorrectVatValue()
        {
            //Arrange
            var invoiceItem = new InvoiceItem();
            int vatParamter = 23;

            //Act
            invoiceItem.SetVatRate(vatParamter);

            //Assert
            Assert.Equal(vatParamter, invoiceItem.GetVatRate());
        }

        [Fact]
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
            Assert.NotNull(expectedException);
        }

        [Fact]
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
            Assert.Equal(expectedException.GetType(), argumentOutOfRangeException.GetType());
        }
    }
}
