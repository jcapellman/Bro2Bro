using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Bro2Bro.Mobile.Interfaces;
using Bro2Bro.PCL.Transports.Global;

using Xamarin.Forms;

namespace Bro2Bro.Mobile.ViewModels {
    public class BaseModel : INotifyPropertyChanged {
        internal ReturnSet<T> ReadObject<T>(string fileName) => DependencyService.Get<ILocalStorage>().Read<T>(fileName);

        internal ReturnSet<T> ReadObject<T>(Type objectType) => DependencyService.Get<ILocalStorage>().Read<T>(objectType);

        internal void WriteObject<T>(string fileName, T objectValue) => DependencyService.Get<ILocalStorage>().Write(fileName, objectValue);

        internal void WriteObject<T>(T objectValue) => DependencyService.Get<ILocalStorage>().Write(objectValue);

        internal void DeleteObject<T>(T objectValue) => DependencyService.Get<ILocalStorage>().Delete<T>(objectValue);

        internal void DeleteObject(string fileName) => DependencyService.Get<ILocalStorage>().Delete(fileName);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}