using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Tests.MSTest
{
    [TestClass]
    public class DBServiceTests
    {
        [TestMethod]
        public void GetAllInvoices_CorrectConnection_ReturnsData()
        {
            // TODO implement test
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAllInvoices_IncorrectConnection_ExceptionOccured()
        {
            // TODO implement test
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InsertInvoice_CorrectConnection_InvoiceDataSaved()
        {
            // TODO implement test
            Assert.IsTrue(true);
        }
    }
}
