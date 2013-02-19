using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Win8Extensions.Converters;
using Windows.UI.Xaml;

namespace Win8Extensions.Test.Converters
{
    [TestClass]
    public class BooleanToVisibilityConverterTest
    {
        [TestMethod]
        public void ConvertTrueTest() {
            var converter = new BooleanToVisibilityConverter();
            var result = converter.Convert(true, typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void ConvertFalseTest()
        {
            var converter = new BooleanToVisibilityConverter();
            var result = converter.Convert(false, typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Collapsed, result);            
        }

        [TestMethod]
        public void ConvertBackVisibleTest() {
            var converter = new BooleanToVisibilityConverter();
            var result = converter.ConvertBack(Visibility.Visible, typeof(bool), null, null);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ConvertBackCollapsedTest() {
            var converter = new BooleanToVisibilityConverter();
            var result = converter.ConvertBack(Visibility.Collapsed, typeof(bool), null, null);
            Assert.AreEqual(false, result);
        }
    }
}
