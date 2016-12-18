﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; 
using System.Windows.Control; 

namespace FileBrowserWindowsApp
{
    class Program
    {
       

        public partial class Page : UserControl
        {
            public Page()
            {
                InitializeComponent();
            }

            private void bOpenFileDialog_Click(object sender, RoutedEventArgs e)
            {
                // Create an instance of the open file dialog box.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set filter options and filter index.
                openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = true;

                // Call the ShowDialog method to show the dialog box.
                bool? userClickedOK = openFileDialog1.ShowDialog();

                // Process input if the user clicked OK.
                if (userClickedOK == true)
                {
                    // Open the selected file to read.
                    System.IO.Stream fileStream = openFileDialog1.File.OpenRead();

                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                    {
                        // Read the first line from the file and write it the textbox.
                        tbResults.Text = reader.ReadLine();
                    }
                    fileStream.Close();
                }
            }
        }
    }
}
    }
}
