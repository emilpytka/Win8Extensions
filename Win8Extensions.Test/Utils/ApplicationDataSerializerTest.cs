using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Win8Extensions.Utils;

namespace Win8Extensions.Test.Utils
{
    [TestClass]
    public class ApplicationDataSerializerTest
    {
        [TestMethod]
        public async Task WriteAndReadDataFromStorage()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;

            var objectToSerialization = new SerializedTestClass() {Text = "Ala ma kota", Value = 120};
            var appDataSerializer = new ApplicationDataSerializer<SerializedTestClass>(folder);

            await appDataSerializer.SaveObject(objectToSerialization, "plik.json");

            var objectFromDeserializtion = await appDataSerializer.GetObject("plik.json");

            Assert.AreEqual("Ala ma kota", objectToSerialization.Text);
            Assert.AreEqual(120, objectFromDeserializtion.Value);
        }
    }


    public class SerializedTestClass
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
