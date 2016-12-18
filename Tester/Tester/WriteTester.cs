using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO; 
namespace Tester
{
    class WriteTester
    {
        private readonly string _folder;
        private int written;
        static Random rand = new Random();
        private readonly List<String> random_names = new List<string>(new string[] { "fire", "shark", "Jason", "a monster", "hoolagins", "clowns", "axe murderer", "spooky ghost" });
        private List<String> GenerateTemplate()
        {
            List<String> template = new List<string>();
            List<String> random_names = new List<string>();
            string date_time = DateTime.Now.ToShortTimeString();
            int rand_num = rand.Next(3, 6);
            template.Add("type:alarm");
            template.Add(string.Format("Date:{0}", date_time));
            template.Add(string.Format("name:{0}", random_names[rand.Next(0, random_names.Count() - 1)]));
            template.Add(string.Format("room:{0}", rand.Next(1, 500)));
            return template;

        }

        private void WriteJson()
        {

            var temp = GenerateTemplate();

            if (!System.IO.File.Exists(_folder))
            {

                using (StreamWriter outFile = new StreamWriter(_folder + written.ToString() + ".json"))
                {
                    int count = 0;
                    outFile.WriteLine("{");
                    foreach (var pair in temp)
                    {
                        outFile.WriteLine(pair);
                        if (!count.Equals(temp.Count() - 1))
                        {
                            outFile.WriteLine(",");
                        }
                        else
                        {
                            outFile.WriteLine("}");
                        }

                    }

                    outFile.Flush();
                    outFile.Close();
                }

            }

        }

        public WriteTester(string input_folder)
        {
            _folder = input_folder;
        }
        public void Start()
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process p = Process.Start(psi);
            StreamWriter sw = p.StandardInput;
            StreamReader sr = p.StandardOutput;
            sw.WriteLine("Write Tester Online: Writting to {0}", _folder);

            sw.WriteLine("Quit with: (q)");
            while (!sr.ReadLine().Equals("q"))

                if (sr.ReadLine().Equals(0))
                {
                    WriteJson();

                }
                else
                {
                    int numberToWrite = Convert.ToInt32(sr.ReadLine());
                    foreach (var num in Enumerable.Range(0, numberToWrite))
                    {
                        WriteJson();

                    }
                }



        }
    }
}

