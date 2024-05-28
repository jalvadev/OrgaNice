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
        public void Order1_NewUnit_ReturnTrue()
        {
            var responseMessage = string.Format(Resources.success_unit_created, TEST_UNIT_NAME);
            var response = BaseWriter.AddUnit(TEST_UNIT_NAME);

            Assert.That(response.Success, Is.True);
            Assert.That(response.Message, Is.EqualTo(responseMessage));
        }

        [Test]
        public void Order2_NewUnitExistent_ReturnFalse()
        {
            var response = BaseWriter.AddUnit(TEST_UNIT_NAME);

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_existent_unit));
        }

        [Test]
        public void NewUnitNotSupportedName_ReturnFalse()
        {
            var response = BaseWriter.AddUnit("Angular:_?");

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_not_supported_name));
        }

        [Test]
        public void DeleteUnitUnexistentUnit_ReturnFalse()
        {
            var unitName = Guid.NewGuid().ToString();
            
            var response = BaseWriter.DeleteUnit(unitName);

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_unexistent_unit));
        }

        [Test]
        public void Order3_DeleteUnit_ReturnTrue()
        {
            var responseMessage = string.Format(Resources.success_unit_deleted, TEST_UNIT_NAME);
            var response = BaseWriter.DeleteUnit(TEST_UNIT_NAME);

            Assert.That(response.Success, Is.True);
            Assert.That(response.Message, Is.EqualTo(responseMessage));
        }


        // Chapter Tests
        [Test]
        public void Order1_NewChapterWithNoUnit_ReturnFalse()
        {
            var unitName = "Unidad 01";
            var chapterName = "Chapter";

            var response = BaseWriter.AddChapter(unitName, chapterName);

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_unexistent_unit));
        }

        [Test]
        public void Order2_NewChapter_ReturnTrue()
        {
            var unitName = "Unidad 01";
            var chapterName = "Chapter";
            var responseMessage = string.Format(Resources.success_chapter_created, chapterName, unitName);
            BaseWriter.AddUnit(unitName);
            var response = BaseWriter.AddChapter(unitName, chapterName);

            Assert.That(response.Success, Is.True);
            Assert.That(response.Message, Is.EqualTo(responseMessage));
        }

        [Test]
        public void Order3_NewChapterDeleteUnit_ReturnFalse()
        {
            var unitName = "Unidad 01";
           
            var response = BaseWriter.DeleteUnit(unitName);

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_unit_not_empty));
        }

        [Test]
        public void Order4_DeleteChapterNotFound_ReturnFalse()
        {
            var unitName = "Unidad 01";
            var chapterName = "Chapter 2";

            var response = BaseWriter.DeleteChapter(unitName, chapterName);

            Assert.That(response.Success, Is.False);
            Assert.That(response.Message, Is.EqualTo(Resources.error_unexistent_chapter));
        }

        [Test]
        public void Order5_DeleteChapter_ReturnTrue()
        {
            var unitName = "Unidad 01";
            var chapterName = "Chapter";
            var responseMessage = string.Format(Resources.success_chapter_deleted, chapterName, unitName);

            var response = BaseWriter.DeleteChapter(unitName, chapterName);
            
            Assert.That(response.Success, Is.True);
            Assert.That(response.Message, Is.EqualTo(responseMessage));

            // Just to clean the folder
            BaseWriter.DeleteUnit(unitName);
        }
    }
}
