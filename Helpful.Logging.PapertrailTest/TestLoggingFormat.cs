using System;
using System.Collections.Generic;
using log4net.Config;
using NUnit.Framework;

namespace Helpful.Logging.PapertrailTest
{
    /// <summary>
    /// Run these tests, check papertrail, see the format.
    /// </summary>
    [TestFixture]
    public class TestLoggingFormat
    {
        [OneTimeSetUp]
        public void Setup()
        {
            XmlConfigurator.Configure();
            LoggingContext.Set("key1", "AAAAAAAAAAAAAAAAAA");
        }

        [Test]
        public void SimpleMessage()
        {
            this.GetLogger().Info("Logging this");
        }

        [Test]
        public void MoreComplex()
        {
            LoggingContext.Set("key2", new
            {
                Key2P1 = "Some property value",
                Key2P2 = 6600
            });
            this.GetLogger().Info(new
            {
                Something = "Some string",
                SomeDate = DateTime.Now,
                SomeCollection = new List<int>
                {
                    1,2,3,4,5,6
                },
                SomeObject = new
                {
                    Inner1 = "Another string",
                    Inner2 = (float?)null
                }
            });
        }
    }
}
