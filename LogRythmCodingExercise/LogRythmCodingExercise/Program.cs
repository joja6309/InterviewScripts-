using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading; 


namespace LogRythmCodingExercise
{

//programming exercise:

//Theoretical situation:
//We have data coming from a security device that outputs json.We need to monitor a folder for new files and process them as as soon as possible.
//The output should be a status of the system with statistics every second.For the purpose of this exercise write code that you would feel comfortable
//deploying in a high performance environment.


//Example:


//Input:
//{"Type":Door, "Date":"2014-02-01 10:01:02", "open": true}
//--new file
//{"Type":Alarm, "Date":"2014-02-01 10:01:01", "name":"fire", "floor":"1", "Room": "101"}

//Output:
//"EventCnt: 1, ImgCnt:0, AlarmCnt:0, avgProcessingTime: 10ms"


//Some example input files should be attached.
//Run Solution from VisulStudio or execute on command line 
    class Program
    {
      
        // Main
        // - Read user input for default folder path (desktop) or (given path) 
        // - Send chosen path into Watch Class 
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to watch folder or use default by entering 0");
            string input_folder; 
            input_folder = Console.ReadLine();
            if(input_folder.Equals("0"))
            {
                 input_folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Default_Folder";
            }
            Watcher folder_watch = new Watcher(input_folder);
            folder_watch.Start();
        }
    }
}
