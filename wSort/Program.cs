using System;
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
        private static string arcDir = "Archives";
        private static string audDir = "Audio";
        private static bool extra;
        private static string jarDir = "Jars";
        static void Main(string[] args)
        {
            if (args.Contains("-extra")) {
                extra = true;
            }

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
            if (!Directory.Exists(arcDir))
            {
                Directory.CreateDirectory(arcDir);
            }
            if (!Directory.Exists(audDir))
            {
                Directory.CreateDirectory(audDir);
            }

            if (extra) {
                if (!Directory.Exists(jarDir))
                {
                    Directory.CreateDirectory(jarDir);
                }
            }

            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory())) {
                var fi = new FileInfo(file);
                switch (fi.Extension) {
                    case ".png":
                    case ".jpg":
                    case ".bmp":
                    case ".tga":
                    case ".jpeg":
                        Mover(file, picDir, fi);
                        break;

                    case ".gif":
                        Mover(file, gifDir, fi);
                        break;

                    case ".zip":
                    case ".rar":
                    case ".7z":
                    case ".tar":
                    case ".gz":
                    case ".bz2":
                    case ".tgz":
                        Mover(file, arcDir, fi);
                        break;

                    case ".mp3":
                    case ".flac":
                    case ".wav":
                    case ".ogg":
                        Mover(file, audDir, fi);
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
                        Mover(file, docDir, fi);
                        break;
                }
                if (extra) {
                    switch (fi.Extension) {
                        case ".jar":
                        case ".war":
                            Mover(file, jarDir, fi);
                            break;
                    }
                }
            }
        }

        private static void Mover(string file, string dir, FileInfo fi) {
            try {
                File.Move(file, dir + "\\" + fi.Name);
            }
            catch (Exception) {
                int i = 1;
                var noex = (dir+"\\"+fi.Name).Replace(fi.Extension, "");
                while (File.Exists(noex+"("+i+")"+fi.Extension)) {
                    i++;
                }
                File.Move(file, noex+"("+i+")"+fi.Extension);
            }
        }
    }
}
