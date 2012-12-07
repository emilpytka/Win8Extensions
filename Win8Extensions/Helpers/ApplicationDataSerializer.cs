using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace Win8Extensions.Helpers
{
    /// <summary>
    /// Class that can serialize and deserialize objects using json. 
    /// Only what you need to do is to send application StorageFolder in constructor. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApplicationDataSerializer<T>
        where T : class
    {
        private readonly StorageFolder _folder;

        public ApplicationDataSerializer(StorageFolder folder) {
            _folder = folder;
        }

        /// <summary>
        /// Return object saved in file which name is send in parameter.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<T> GetObject(string filename) {
            var file = await _folder.GetFileAsync(filename);

            if (file != null) {
                var reader = await file.OpenReadAsync();
                var streamReader = new StreamReader(reader.AsStream());
                var text = streamReader.ReadToEnd();

                var serializer = new JsonSerializer<T>();
                var result = serializer.Deserialize(text);

                return result;
            }
            return null;
        }


        /// <summary>
        /// Save object to file.
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task SaveObject(T objectToSave, string filename) {

            var file = await _folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenStreamForWriteAsync()) {

                var serializer = new JsonSerializer<T>();
                var json = serializer.Serialize(objectToSave);

                var streamWriter = new StreamWriter(stream);
                streamWriter.Write(json);
            }
        }


    }
}
