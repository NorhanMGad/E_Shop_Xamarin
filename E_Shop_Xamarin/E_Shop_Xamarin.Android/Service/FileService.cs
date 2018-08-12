using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using E_Shop_Xamarin.Droid.Service;
using E_Shop_Xamarin.IServices;
using Java.IO;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace E_Shop_Xamarin.Droid.Service
{
    public class FileService : IFileService
    {

        public string RetrivePictureFullPath(string name)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Images");
            string fullPath = Path.Combine(documentsPath, name);
            return fullPath;
        }

        public bool IfExsist(string name)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Images");
            string filePath = Path.Combine(documentsPath, name);
            if (System.IO.File.Exists(filePath))
                return true;
            return false;
        }

        public async void SavePicture(string name, byte[] data)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Images");

            if(!Directory.Exists(documentsPath))
                Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, name);

            if (!System.IO.File.Exists(filePath))
            {
                using (FileStream fileOutputStream = System.IO.File.Open(filePath, FileMode.OpenOrCreate))
                {
                    fileOutputStream.Seek(0, SeekOrigin.End);
                    await fileOutputStream.WriteAsync(data, 0, data.Length);
                }
            }
        }
    }
}