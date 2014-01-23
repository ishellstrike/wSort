﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace wSort
{
    class Program {
        private static string picDir = "Pictures";
        private static string gifDir = "Animations";
        private static string docDir = "Documents";
        static void Main(string[] args)
        {
            if (!Directory.Exists(picDir)) {
                Directory.CreateDirectory(picDir);
            }
            if (!Directory.Exists(gifDir))
            {
                Directory.CreateDirectory(gifDir);
            }
            if (!Directory.Exists(docDir))
            {
                Directory.CreateDirectory(docDir);
            }

            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory())) {
                var fi = new FileInfo(file);
                switch (fi.Extension) {
                    case ".png":
                    case ".jpg":
                    case ".bmp":
                    case ".tga":
                    case ".jpeg":
                        File.Move(file, picDir + "\\" + fi.Name);
                        break;

                    case ".gif":
                        File.Move(file, gifDir + "\\"+ fi.Name);
                        break;

                    case ".txt ":
                    case ".pas":
                    case ".doc":
                    case ".docx":
                    case ".pdf":
                    case ".xlsx":
                    case ".xls":
                    case ".rtf":
                    case ".psd":
                    case ".mcdx":
                    case ".xps":
                    case ".dpr":
                        File.Move(file, docDir + "\\" + fi.Name);
                        break;
                }
            }
        }
    }
}
