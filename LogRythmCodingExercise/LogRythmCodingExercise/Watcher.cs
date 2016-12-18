using System;
using System.Timers; 
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Diagnostics;



namespace LogRythmCodingExercise
{

    //Watcher Class
    // - contains information on file write events to folder 
    // - displays information after each file write
    // - processes writen file, prints status of directory 


    public class Watcher
    {
        private static FileSystemWatcher watcher; // used to check for file write events 
        private readonly string folder_path; // path to folder that is being watched 
        private int file_number = 0; // number of files in folder 
        // Maintains status of folder 
        private Dictionary<string, int> StatusDictionary = new Dictionary<string, int>();
        // Maintains processing time of all write events
        private List<long> ProcessingTime = new List<long>();
        // Maintains average processing time of all write events 
        private double averageProcessingTime; 
        //Compute Average
        // in: list of long 
        // out: none 
        // - sums up all processing event processing times and sets a new average 
        private void ComputeAverage(List<long> processing_events)
        {
            double total_sum = 0;
            foreach(var ev in processing_events) 
            {
                total_sum = total_sum + ev; 
            }
            averageProcessingTime = total_sum / processing_events.Count();
            return; 
        }
        // Print Status
        // in: none 
        // out: none 
        // - writes a count on all of the event types and the average processing time to console 
        private void PrintStatus()
        {
            
                Console.WriteLine("Directory Status: ");
                foreach (var key in StatusDictionary.Keys)
                {
                    Console.Write(string.Format(key + ":" + "{0} ", StatusDictionary[key]));
                }
                Console.WriteLine("|| Average Processing Time: {0} ms", averageProcessingTime);
            return;
        }
        //AddToStatus
        // in : string containing the type of event
        // out: none 
        // - increments status dictionary if a new event is added or creates a new event type 
        private void AddToStatus(string event_type)
        {
            string[] pairs = event_type.Split(':');
            string clean_type = pairs[1].Trim(',', ' ');
            if (StatusDictionary.Keys.Contains(clean_type))
                StatusDictionary[clean_type] += 1;
            else
                StatusDictionary.Add(clean_type, 1);
            return; 
        }


        //Constructor 
        // in: folder path
        // out: none
        // - creates folder at specified path
        public Watcher(string in_path)
        {
            folder_path = in_path;
            BuildFolder(in_path);
        }

        //ProcessFile 
        // in: path to file that was just added 
        // out: bool indicating that everything was processed correctly 
        // - processes the incoming file and sends string containig the event type to the status dic 
        private bool ProcessFile(string file_path)
        {
            var inputFile = File.ReadAllLines(file_path);
            string new_event = "";
            foreach (var line in inputFile)
            {
                string clean_string = line.Trim('}', '{', ',');
                new_event = new_event += " " + clean_string;
                if (clean_string.Contains("Type"))
                {
                    AddToStatus(new_event);
                }

            }
            return true;
        }
        //BuildFolder
        // in: string containg the folder path
        // out: bool indicating that everthing was fine 
        // - creates folder at specified path if one does not already exist
        private bool BuildFolder(string fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(fullPath);

            }
            return true;
        }
        //OnDirectoryChanged
        // in: system event and sender object 
        // out: none 
        // This is main folder watching logic 
        // checks that processing time of the file that was added to the directory 
        private void OnDirectoryChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                // the code that you want to measure comes here
               
                watcher.EnableRaisingEvents = false;
                Console.WriteLine("{0} Added", e.Name.ToString());
                var watch = System.Diagnostics.Stopwatch.StartNew();
                ProcessFile(e.FullPath.ToString());
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                ProcessingTime.Add(elapsedMs);
                ComputeAverage(ProcessingTime);
                Console.WriteLine("{0} Processed", e.Name.ToString());
                file_number = file_number + 1 ;
                PrintStatus();

                /* do my stuff once */
            }

            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }
        // GrantAccess 
        // in: folder path
        //out: bool indicating that everything was executed correctly 
        private bool GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            dInfo.Attributes &= ~FileAttributes.ReadOnly;
            return true;
        }
        //Start 
        // - in: none 
        // - out: none 
        // - core loop that runs this program, takes user input (q) for exit 
        // - instantiates the folder watcher 

        public void Start()
        {
            watcher = new System.IO.FileSystemWatcher();
            watcher.Path = folder_path;
            watcher.NotifyFilter =
                     NotifyFilters.LastWrite;
            watcher.Changed += new FileSystemEventHandler(OnDirectoryChanged);
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("Press (q) to stop watching: ");
            Console.WriteLine("Press (h) to view all processed events: ");
            Console.WriteLine("Press (s) to view the directory status: ");
            Console.WriteLine("Directory under surveilance {0}", folder_path);
            GrantAccess(folder_path);
            while (!Console.ReadLine().Contains('q'))
            {
                
               
            }
        }

    }
} 
