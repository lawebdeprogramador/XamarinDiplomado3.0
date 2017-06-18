using System;
using System.IO;

namespace SharedProject
{
    class MySharedCode
    {
        public string GetFilePath(string fileName)
        {
#if WINDOWS_UWP
            var filePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
#elif __ANDROID__
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(libraryPath, fileName);
#elif __WPF__
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(libraryPath, fileName);
#endif
            return filePath;
        }
    }
}
