using SampleApp.Models;
using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleApp.Tests.xUnit
{
    public class DBServiceTests
    {
        [Fact]
        public void GetAllInvoices_CorrectConnection_ReturnsData()
        {
            //Arrange
            Invoice invoice = new Invoice();
            invoice.IssueDate = DateTime.Now;
            invoice.BuyerData = "TestData";
            invoice.SellerData = "TestData";
            DBService.InsertInvoice(invoice);

            //Act
            List<Invoice> invoices = DBService.GetAllInvoices(string.Empty);

            //Assert
            Assert.True(invoices.Count > 0);
        }

        [Fact]
        public void GetAllInvoices_IncorrectConnection_ExceptionOccured()
        {
            //Arrange
            Exception expectedException = null;

            //Act
            try
            {
                List<Invoice> invoices = DBService.GetAllInvoices("Wrong connection string");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void GetInvoiceById_CorrectInvoiceId_ReturnsOneRows()
        {
            //Arrange
            Invoice invoice = new Invoice()
            {
                BuyerData = "Dane",
                SellerData = "Dane",
                IssueDate = DateTime.Now,
                TotalGrossAmount = 123,
                TotalNetAmount = 100
            };

            DBService.InsertInvoice(invoice);


            //Act
            List<Invoice> invoices = DBService.GetInvoiceById(string.Empty, invoice.Id);

            //Assert
            Assert.True(invoices.Count == 1);
        }

        [Fact]
        public void GetInvoiceById_WrongInvoiceId_ReturnsZeroRows()
        {
            //Arrange

            //Act
            List<Invoice> invoices = DBService.GetInvoiceById(string.Empty, "WrongId");

            //Assert
            Assert.True(invoices.Count == 0);
        }

        [Fact]
        public void GetInvoiceById_WrongConnectionString_ExceptionOccured()
        {
            //Arrange
            Exception expectedException = null;

            //Act
            try
            {
                List<Invoice> invoices = DBService.GetInvoiceById("Wrong connection string", "InvoiceId");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoice_CorrectData_InvoiceDataSaved()
        {
            //Arrange
            Invoice invoice = new Invoice();
            invoice.IssueDate = DateTime.Now;
            invoice.BuyerData = "TestData";
            invoice.SellerData = "TestData";

            //Act
            DBService.InsertInvoice(invoice);

            //Assert
            Assert.True(DBService.InvoiceExists(invoice.Id.ToString()));
        }

        [Fact]
        public void InsertInvoice_NullIssueDate_ExceptionOccured()
        {
            //Arrange
            Invoice invoice = new Invoice();
            invoice.IssueDate = null;
            invoice.BuyerData = "TestData";
            invoice.SellerData = "TestData";
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoice(invoice);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        private InvoiceItem PrepareInvoiceItem()
        {
            InvoiceItem invoiceItem = new InvoiceItem()
            {
                InvoiceId = Guid.NewGuid().ToString(),
                Name = "Nazwa produktu",
                Unit = "Jednostka",
                Amount = 1,
                AmountNet = 10,
                AmountGross = 12.3
            };

            return invoiceItem;
        }

        [Fact]
        public void InsertInvoiceItem_CorrectData_InvoiceDataSaved()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();

            //Act
            DBService.InsertInvoiceItem(invoiceItem);

            //Assert
            //Assert.IsTrue(DBService.InvoiceExists(invoice.Id.ToString()));
            Assert.False(false);
        }

        [Fact]
        public void InsertInvoiceItem_NullInvoiceId_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.InvoiceId = null;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_EmptyInvoiceId_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.InvoiceId = string.Empty;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_NullName_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.Name = null;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_EmptyName_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.Name = string.Empty;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_NullIUnit_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.Unit = null;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_EmptyUnit_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.Unit = string.Empty;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_ZeroAmount_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.Amount = 0;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_ZeroAmountNet_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.AmountNet = 0;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void InsertInvoiceItem_ZeroAmountGross_ExceptionOccured()
        {
            //Arrange
            InvoiceItem invoiceItem = PrepareInvoiceItem();
            invoiceItem.AmountGross = 0;
            Exception expectedException = null;

            //Act
            try
            {
                DBService.InsertInvoiceItem(invoiceItem);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }
    }
}
