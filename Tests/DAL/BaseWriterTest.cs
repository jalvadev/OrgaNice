using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgaNice.DAL;
using OrgaNice.Responses;
using OrgaNice.Properties;

namespace Tests.DAL
{
    [TestFixture]
    internal class BaseWriterTest
    {

        [Test]
        public void NewFolderExistent_ReturnFalse()
        {
            BaseWriter.AddUnit("Angular");

            var response = BaseWriter.AddUnit("Angular");

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_existent_unit));
        }

        [Test]
        public void NewFolderNotSupportedName_ReturnFalse()
        {
            var response = BaseWriter.AddUnit("Angular:_?");

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_not_supported_name));
        }
    }
}
