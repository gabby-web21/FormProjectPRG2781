using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Data; 

namespace FormProjectPRG2781
{
    internal class Settings
    {
        public string iniPath = Application.StartupPath + @"\config.txt";

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string sectionName, string keyName, string defaultValue, StringBuilder returnedString, int size, string fileName);

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string section, string keyName, string value, string path);

        public StringBuilder sbTheme;
        public string theme { get; set; }

        public void readIni()
        {
            sbTheme = new StringBuilder(10);
            GetPrivateProfileString("SECTION", "key", "", sbTheme, sbTheme.Capacity, iniPath);
            this.theme = sbTheme.ToString();
        }

        public void writeIni(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, iniPath);
        }
    }
}
