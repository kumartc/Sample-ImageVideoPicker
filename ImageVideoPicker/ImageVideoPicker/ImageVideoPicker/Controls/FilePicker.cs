using ImageVideoPicker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageVideoPicker.Controls
{
    public static class FilePicker
    {
        public static string GetUniquePath(MediaFile type, string path, string name)
        {
            string ext = Path.GetExtension(name);
            if (ext == string.Empty)
                ext = ((type == MediaFile.Image) ? ".jpg" : ".mp4");

            name = Path.GetFileNameWithoutExtension(name);

            string nname = name + ext;
            int i = 1;
            while (File.Exists(Path.Combine(path, nname)))
                nname = name + "_" + (i++) + ext;

            return Path.Combine(path, nname);
        }


        public static string GetOutputPath(MediaFile type, string path, string name)
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), path);
            Directory.CreateDirectory(path);

            if (string.IsNullOrWhiteSpace(name))
            {
                string timestamp = DateTime.Now.ToString("yyyMMdd_HHmmss");
                if (type == MediaFile.Image)
                    name = "IMG_" + timestamp + ".jpg";
                else
                    name = "VID_" + timestamp + ".mp4";
            }

            return Path.Combine(path, GetUniquePath(type, path, name));
        }
    }
}
