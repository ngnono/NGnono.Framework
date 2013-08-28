
using NGnono.Framework.Logger;
using NUnit.Framework;

namespace NGnono.Framework.Test.Logger
{
    [TestFixture]
    public class LoggerTest
    {

        private ILog logger;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            this.logger = LoggerManager.Current();
        }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        public void CommonTest()
        {
            logger.Debug("debug");
            logger.Error("error");
            logger.Fatal("fatal");
            logger.Info("info");
            logger.Warn("warn");

            Assert.IsFalse(false);
        }

        #endregion
    }
}
