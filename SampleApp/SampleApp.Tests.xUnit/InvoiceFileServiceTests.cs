using SampleApp.Models;
using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleApp.Tests.xUnit
{
    public class InvoiceFileServiceTests
    {
        [Fact]
        public void SaveInvoiceFile_CorrectFilePath_FileSaved()
        {
            Invoice invoice = new Invoice();

            InvoiceFileService.SaveInvoiceFile(invoice);

            Assert.True(File.Exists(invoice.GetFilePath()));

        }

        [Fact]
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
            Assert.False(File.Exists(filPath));

        }

        [Fact]
        public void DownloadInvoiceFile_FileExists_FileDownloaded()
        {
            //Arrange
            string sourceFilePath = @"C:\Invoices\00000000-0000-0000-0000-000000000000.xml";
            string downloadingFilePath = @"C:\Invoices\Downloads\00000000-0000-0000-0000-000000000000.xml";

            //Act
            InvoiceFileService.DownloadInvoiceFile("", sourceFilePath, downloadingFilePath);

            //Assert
            Assert.True(File.Exists(downloadingFilePath));

        }

        [Fact]
        public void DownloadInvoiceFile_WrongInvoiceId_ExceptionOccured()
        {
            //Arrange
            string sourceFilePath = @"C:\Invoices\wrongid.xml";
            string downloadingFilePath = @"C:\Invoices\Downloads\00000000-0000-0000-0000-000000000000.xml";
            Exception expectedException = null;

            //Act
            try
            {
                InvoiceFileService.DownloadInvoiceFile("", sourceFilePath, downloadingFilePath);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.NotNull(expectedException);
        }

        [Fact]
        public void DownloadInvoiceFile_WrongInvoiceId_CorrectExceptionOccured()
        {
            //Arrange
            string sourceFilePath = @"C:\Invoices\wrongid.xml";
            string downloadingFilePath = @"C:\Invoices\Downloads\00000000-0000-0000-0000-000000000000.xml";
            Exception expectedException = null;
            var fileNotFoundException = new FileNotFoundException();

            //Act
            try
            {
                InvoiceFileService.DownloadInvoiceFile("", sourceFilePath, downloadingFilePath);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.Equal(expectedException.GetType(), fileNotFoundException.GetType());
        }
    }
}
