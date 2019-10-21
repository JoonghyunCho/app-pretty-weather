using NUnit.Framework;
using System.Threading;

namespace UITestApp
{
    [TestFixture]
    public class Tests
    {
        TizenDriverApp Driver;

        [OneTimeSetUp]
        public void Setup()
        {
            Driver = AppInitializer.StartApp();
            Thread.Sleep(3000);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        /// <summary>
        /// Test to element click
        /// </summary>
        public void Click()
        {
            Driver.Click("Saint Louis");
            Thread.Sleep(2500);
            string text = Driver.GetText("cityName_label");
            Assert.True(text == "Saint Louis");

        }

        [Test]
        /// <summary>
        /// Test to get text of element
        /// </summary>
        public void GetText()
        {
            //Driver.SetText("Label", "Hello Tizen");
            //string text = Driver.GetText("Label");
            //Assert.True(text == "Hello Tizen");
        }

        [Test]
        /// <summary>
        /// Test to set text of element
        /// </summary>
        public void SetText()
        {
            //Driver.SetText("Entry", "Set Entry");
            //string text = Driver.GetText("Entry");
            //Assert.True(text == "Set Entry");
        }
    }
}
