using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Win8Extensions.Converters;
using Windows.UI.Xaml;

namespace Win8Extensions.Test.Converters
{
    [TestClass]
    public class ObjectToVisibilityConverterTest
    {
        [TestMethod]
        public void ConvertNotNullObjectTest() {
            var converter = new ObjectToVisibilityConverter();
            var result = converter.Convert(new object(), typeof(object), null, null);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void ConvertNullObjectTest() {
            var converter = new ObjectToVisibilityConverter();
            var result = converter.Convert(null, typeof(object), null, null);
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void ConvertBackTest() {
            var converter = new ObjectToVisibilityConverter();
            Assert.ThrowsException<NotImplementedException>(
                () => converter.ConvertBack(Visibility.Collapsed, typeof (Visibility), null, null));
        }
    }
}
