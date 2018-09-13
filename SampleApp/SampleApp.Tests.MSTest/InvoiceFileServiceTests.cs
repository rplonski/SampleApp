using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp.Models;
using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Tests.MSTest
{
    [TestClass]
    public class InvoiceFileServiceTests
    {
        [TestMethod]
        public void SaveInvoiceFile_CorrectFilePath_FileSaved()
        {
            Invoice invoice = new Invoice();

            InvoiceFileService.SaveInvoiceFile(invoice);

            Assert.IsTrue(File.Exists(invoice.GetFilePath()));
            
        }

        [TestMethod]
        public void SaveInvoiceFile_IncorrectFilePath_FileUnsaved()
        {
            Invoice invoice = new Invoice();
            invoice.SetFilePath(@"Wrong\path.wrongpath.xml/wrongpath");

            try
            {
                InvoiceFileService.SaveInvoiceFile(invoice);
            }
            catch { }

            var filPath = invoice.GetFilePath();
            Assert.IsFalse(File.Exists(filPath));

        }
    }
}
