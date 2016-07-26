using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Bro2Bro.Mobile.Interfaces;

namespace Bro2Bro.Mobile.Droid.Interfaces {
    public class LocalStorage : ILocalStorage {
        public void Write<T>(string filename, T objectValue) {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var filePath = Path.Combine(documentsPath, filename);

            var jsonStr = JsonConvert.SerializeObject(objectValue);

            var fileBytes = Encoding.ASCII.GetBytes(jsonStr);

            File.WriteAllBytes(filePath, fileBytes);
        }

        public T Read<T>(string filename) {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            
            var fileBytes = File.ReadAllBytes(filePath);

            var jsonStr = System.Text.Encoding.UTF8.GetString(fileBytes);

            return (T)JsonConvert.DeserializeObject(jsonStr);
        }

        public void Write<T>(T objectValue) {
            Write(objectValue.GetType().Name, objectValue);
        }

        public T Read<T>(Type objectType) => Read<T>(objectType.Name);

        public void Delete<T>(T objectValue) {
            Delete<T>(objectValue.GetType().Name);
        }

        public void Delete<T>(string fileName) {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);

            File.Delete(filePath);
        }
    }
}