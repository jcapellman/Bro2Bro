using System;

namespace Bro2Bro.Mobile.Interfaces {
    public interface ILocalStorage {
        void Write<T>(T objectValue);

        void Write<T>(string filename, T objectValue);

        T Read<T>(string filename);

        T Read<T>(Type objectType);

        void Delete<T>(T objectValue);

        void Delete<T>(string fileName);
    }
}