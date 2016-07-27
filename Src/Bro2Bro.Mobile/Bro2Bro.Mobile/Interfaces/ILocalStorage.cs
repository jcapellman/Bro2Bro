using System;

using Bro2Bro.PCL.Transports.Global;

namespace Bro2Bro.Mobile.Interfaces {
    public interface ILocalStorage {
        void Write<T>(T objectValue);

        void Write<T>(string filename, T objectValue);

        ReturnSet<T> Read<T>(string filename);

        ReturnSet<T> Read<T>(Type objectType);

        void Delete<T>(T objectValue);

        void Delete<T>(string fileName);
    }
}