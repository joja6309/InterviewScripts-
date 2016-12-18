using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics; 


namespace FileWriteTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //File.Create(desktopPath + "testfile.txt");
            string replacement = "KK"; 
            string fp = desktopPath + @"\" + "testfile.txt"; 
            var text = new StringBuilder(); 
            foreach(string s in File.ReadAllLines(fp))
            {
              text.AppendLine(s.Replace("SS","SS" + Environment.NewLine + replacement));   
              
            }
            using (var file = new StreamWriter(File.Create(fp)))
            {
                file.Write(text.ToString());
            }
            Process.Start("notepad.exe", fp); 


        }
    }
}
