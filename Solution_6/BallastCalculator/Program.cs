using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace BallastCalculator
{
   
    class Program
    {

        //private void Write_to_file(IFIPerimeter perm)
        //{
        //    string current_directory = Directory.GetCurrentDirectory();
        //    string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\Output.txt"))
        //    {
        //        outputFile.Write("perm SECTION VALUES ");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("====================");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Corner 1: {0} ", BlockPerimeter.Corner1);
        //        outputFile.Write(Environment.NewLine
        //            );

        //        outputFile.Write("Corner 2: {0} ", BlockPerimeter.Corner2);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Corner 3: {0} ", BlockPerimeter.Corner3);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Corner 4: {0} ", BlockPerimeter.Corner4);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Center : {0}", BlockPerimeter.Center);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("perm Dimensions: ");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("==================");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Width: {0}", BlockPerimeter.Width);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Height: {0}", BlockPerimeter.Height);
        //        outputFile.Write(Environment.NewLine);


        //        outputFile.Write("IFI Values:");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("============");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Corner 1: {0}", IFIBoarder.Corner1);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Corner 2: {0}", IFIBoarder.Corner2);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Corner 3: {0}", IFIBoarder.Corner3);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Corner 4: {0}", IFIBoarder.Corner4);
        //        outputFile.Write(Environment.NewLine);


        //        outputFile.Write("IFI Dimensions: ");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("==================");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Width: {0}", IFIBoarder.Width);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("Height: {0}", IFIBoarder.Height);
        //        outputFile.Write(Environment.NewLine);


        //        outputFile.Write("Panel/Entities Values:");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("======================");
        //        outputFile.Write(Environment.NewLine);


        //        int count2 = 0;
        //        foreach (var x in PanelList)
        //        {
        //            outputFile.Write("Panel Number {0}: ", count2);
        //            outputFile.Write(Environment.NewLine);

        //            outputFile.Write("X value: {0}", x.Xvalue.ToString());
        //            outputFile.Write(Environment.NewLine);

        //            outputFile.Write("Y Value: {0} ", x.Yvalue.ToString());
        //            outputFile.Write(Environment.NewLine);

        //            outputFile.Write("Center Value: {0}", x.Center.ToString());
        //            outputFile.Write(Environment.NewLine);

        //            outputFile.Write("Panel NE_Zone: {0}", x.NE_Zone.ToString());
        //            outputFile.Write(Environment.NewLine);


        //            count2 += 1;
        //        }

        //        outputFile.Write("IFI Corners: ");
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("North East Corner: {0}", perm.NE_corner);
        //        outputFile.Write(Environment.NewLine);

        //        outputFile.Write("North west Corner: {0}", perm.NW_corner);
        //        outputFile.Write(Environment.NewLine);

        //    }


        //}

        //5 and 9 (n) value check 
        // Neighboring lift modules 5 
        // Neighboring sliding modules 8 

        /// <summary>
        /// Function to organize corners of each perm 
        /// c1 = NW corner 
        /// c2 = NE corner 
        /// c3 = SW corner 
        /// c4 = SE corner 
        /// </summary>
        string LandOrPor = "";

        string DefOrNodef = "";

        public void GetUserInputs()
            {
              while(true)
                {
                Console.WriteLine("Input Landscape or Portrait Mode (l/p)");
                LandOrPor = Console.ReadLine();
                Console.WriteLine("Input with deflector or without deflector (w/wo)");
                DefOrNodef = Console.ReadLine();
                bool LOrPCheck = false;
                bool DefOrNodefCheck = false;

                if (LandOrPor.Equals("l"))
                {
                    LOrPCheck = true;

                }
                else if (LandOrPor.Equals("p"))
                {
                    LOrPCheck = true;
                }
                else if (DefOrNodef.Equals("w"))
                {
                    DefOrNodefCheck = true;
                }
                else if (DefOrNodef.Equals("wo"))
                {
                    DefOrNodefCheck = true;
                }
                if ((LOrPCheck && DefOrNodefCheck) != true)
                {
                    Console.WriteLine("Incorect Input Flags Try Again.......");

                }
                else
                {
                    break;
                }
                return;

            }
                   
        }
    
        static void Main(string[] args)
            {
                //GetUserInputs()
                Console.WriteLine("Press Enter to Continue: ");
                DxfParser file_data = new DxfParser("file_name");
                //Console.WriteLine("Copy and Paste the input file path");
                //string IncomingFilePath = Console.ReadLine(); 
                //IncomingFilePath = 
                file_data.ParseFile();
                file_data.ParseEntities();

                BasicDimensions BlockPerimeter = file_data.ParseBlocks();
            
                IFIPerimeter IFIboarder = file_data.IFIBoarder;

                List<Panel> PanelList = file_data.PanelList;

                IFIboarder.CalculateIFICenter();

                IFIboarder.SetCorners();


                foreach (Panel panel in PanelList)
                {
                    panel.CalculatePanelCenter(IFIboarder.Center.Item1, IFIboarder.Center.Item2);
                }

                foreach (Panel panel in PanelList)
                {
                    panel.SetPanelZones(IFIboarder);
                }
           
                Console.WriteLine("Input (N) radius that should be checked: ");

                string input_string = Console.ReadLine();

                int input_n = 0;

                if (string.IsNullOrEmpty(input_string))
                {
                    input_n = 3;

                }
                else
                {
                    input_n = Convert.ToInt32(input_string);

                }

                PanelGrid grid = new PanelGrid(BlockPerimeter, PanelList);

                IFIboarder.PrintIFIData();

                grid.PrintPanelData();
            
            }
        }
    }

    // land = 10 deg 
    // port = 5 deg 

    //deflector 
    // - pair 8 conditions 
    //- pair 8 conditions 

    //Write to Uplift 
    //Write to Sliding 


    //InOut Excel
    //Landscape or Portrait     --> What cells to reference in file 
    //With without deflectors  --> 

    //Use roof zone 
    // East 2 West true col -> with give us 
    //West 2 East true col 
    //IFI North 
    //IFI South 

    //