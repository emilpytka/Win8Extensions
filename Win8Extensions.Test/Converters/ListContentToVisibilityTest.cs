using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Win8Extensions.Converters;
using Windows.UI.Xaml;

namespace Win8Extensions.Test.Converters
{
    [TestClass]
    public class ListContentToVisibilityTest
    {
        [TestMethod]
        public void ConvertNonEmptyListTest() {
            var list = new List<string> { "Ala ma kota" };
            var converter = new ListContentToVisibility();
            var result = converter.Convert(list, typeof(List<string>), null, null);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void ConvertEmptyListTest() {
            var list = new List<string>();
            var converter = new ListContentToVisibility();
            var result = converter.Convert(list, typeof(List<string>), null, null);
            Assert.AreEqual(Visibility.Collapsed, result);
        }


        [TestMethod]
        public void ConvertBackTest() {
            var converter = new ListContentToVisibility();
            Assert.ThrowsException<NotImplementedException>(() =>
                    converter.ConvertBack(Visibility.Collapsed,
                                          typeof(Visibility), null,
                                          null)
                );
        }
    }
}
