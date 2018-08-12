using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.IServices
{
    public interface IFileService
    {
        void SavePicture(string name, byte[] data);
        string RetrivePictureFullPath(string name);
        bool IfExsist(string name);
    }
}
