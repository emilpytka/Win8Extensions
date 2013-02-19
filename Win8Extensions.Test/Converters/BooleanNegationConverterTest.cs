using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Win8Extensions.Converters;

namespace Win8Extensions.Test.Converters
{
    [TestClass]
    public class BooleanNegationConverterTest
    {
        [TestMethod]
        public void ConvertTest()
        {
            var converter = new BooleanNegationConverter();
            var result = converter.Convert(true, typeof (bool), null, null);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ConvertBackTest()
        {
            var converter = new BooleanNegationConverter();
            var result = converter.ConvertBack(false, typeof(bool), null, null);
            Assert.AreEqual(true, result);            
        }
    }
}
