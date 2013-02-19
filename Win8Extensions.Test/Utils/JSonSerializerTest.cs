using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Win8Extensions.Utils;

namespace Win8Extensions.Test.Utils
{
    /// <summary>
    /// Test class for JsonSerializer object. 
    /// </summary>
    [TestClass]
    public class JsonSerializerTest
    {

        [TestMethod]
        public void SerializeTest()
        {
            var serializationObject = new SerializedTestClass();
            serializationObject.Text = "alamakota";
            serializationObject.Value = 12;

            var jsonSerializer = new JsonSerializer<SerializedTestClass>();
            var json = jsonSerializer.Serialize(serializationObject);


            Assert.AreNotEqual(String.Empty, json);
            Assert.AreEqual("{\"Text\":\"alamakota\",\"Value\":12}", json);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var json = "{\"Text\":\"alamakota\",\"Value\":12}";
            var serializer = new JsonSerializer<SerializedTestClass>();
            var deserializedObject = serializer.Deserialize(json);

            Assert.AreEqual("alamakota", deserializedObject.Text);
            Assert.AreEqual(12, deserializedObject.Value);

        }


    }
}
