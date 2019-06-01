using System;
using System.Collections.Generic;
using System.Text;

namespace ImageVideoPicker.Model
{
    public class Files
    {
        public string PreviewPath { get; set; }
        public string Path { get; set; }
        public MediaFile Type { get; set; }
    }

    public enum MediaFile
    {
        Image,
        Video
    }

   
}
