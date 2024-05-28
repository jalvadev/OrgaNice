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
        private const string TEST_UNIT_NAME = "Angular";

        [Test]
        public void NewFolder_ReturnTrue()
        {
            var responseMessage = string.Format(Resources.success_unit_created, TEST_UNIT_NAME);
            var response = BaseWriter.AddUnit(TEST_UNIT_NAME);

            Assert.That(response.Success, Is.True);
            Assert.That(response.Message, Is.EqualTo(responseMessage));
        }

        [Test]
        public void NewFolderExistent_ReturnFalse()
        {
            var response = BaseWriter.AddUnit(TEST_UNIT_NAME);

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
