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
    }
}
