using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingHelper.Util
{
    public class Ini
    {
        string fileName;

        public Ini(string fileName)
        {
            this.fileName = fileName;
        }

        // The Win32 API methods
        [DllImport("kernel32", SetLastError = true)]
        static extern int WritePrivateProfileString(string section, string key, string value, string fileName);
        [DllImport("kernel32", SetLastError = true)]
        static extern int WritePrivateProfileString(string section, string key, int value, string fileName);
        [DllImport("kernel32", SetLastError = true)]
        static extern int WritePrivateProfileString(string section, int key, string value, string fileName);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder result, int size, string fileName);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, int key, string defaultValue, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(int section, string key, string defaultValue, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);

        public void SetValue(string section, string entry, string value)
        {
            if (WritePrivateProfileString(section, entry, value, fileName) == 0)
                throw new Win32Exception();
        }

        public string GetValue(string section, string entry)
        {
            for (int maxSize = 250; true; maxSize *= 2)
            {
                StringBuilder result = new StringBuilder(maxSize);
                int size = GetPrivateProfileString(section, entry, "", result, maxSize, fileName);

                if (size < maxSize - 1)
                {
                    if (size == 0)
                        return "";
                    return result.ToString();
                }
            }
        }
    }
}
