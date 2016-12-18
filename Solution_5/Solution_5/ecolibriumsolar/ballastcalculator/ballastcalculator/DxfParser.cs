using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Threading;

namespace BallastCalculator
{
    
    class DxfParser
    {
        //perims Section (Template) -> Solar Pannel Dimensions -> LxW 
        // - points of each solar panel 
        // - 4 corners 
        // perm 
        // 3 
        // permNAME 
        //7602 
        //10500,10510
        //10568
        //sw315, AcDbPolyline
        // Find all lines containing 10deg or 5deg 
        // From those, show all unique titles 
        // Let the user choose relavent solar panel 
        // if 10deg or 5deg does not return anything 
        // prompt user to input name 
        // if does not return an error 
        // 
        //IFI NUMBER 
        // - 4 coordinates 

        //Entities Section 
        // - XY solar panel location (top left + top left corner ) 
        // - Entity Number 
        // 

        // Min X and Max Y of IFI 
        // Min X and Min Y 

        // X1 should be greater than X2 
        // Y1 should be greater than Y2 
        // X1 Y1 North west corner 
        // X2 Y2 Largest X, Y 

        // Center point of each module 
        // Entity point + calculated center point 
        // Use calculated center point and NE_Zone pattern to place each module in correct NE_Zone 

        // Excel calculation 



        private string[] lines = File.ReadAllLines(@"C:\Users\Owner\Desktop\Solution_5\Solution_5\ecolibriumsolar\ballastcalculator\ballastcalculator\IFI PERIM & sw315w & bases.dxf");
        public void OutPutData()
        {
            PrintpermData();
            PrintIFIData();
            PrintPanelData();
            return; 
        }
       
        private void Write_to_file(IFI_Perimeter perm)
        {
            string current_directory = Directory.GetCurrentDirectory();
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(current_directory + @"\Output.txt"))
            {
                outputFile.Write("perm SECTION VALUES ");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("====================");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Corner 1: {0} ", p_perm.Corner1);
                outputFile.Write(Environment.NewLine
                    );

                outputFile.Write("Corner 2: {0} ", p_perm.Corner2);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Corner 3: {0} ", p_perm.Corner3);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Corner 4: {0} ", p_perm.Corner4);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Center : {0}", p_perm.Center);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("perm Dimensions: ");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("==================");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Width: {0}", p_perm.Width);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Height: {0}", p_perm.Height);
                outputFile.Write(Environment.NewLine);


                outputFile.Write("IFI Values:");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("============");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Corner 1: {0}", IFI_Boarder.Corner1);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Corner 2: {0}", IFI_Boarder.Corner2);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Corner 3: {0}", IFI_Boarder.Corner3);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Corner 4: {0}", IFI_Boarder.Corner4);
                outputFile.Write(Environment.NewLine);


                outputFile.Write("IFI Dimensions: ");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("==================");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Width: {0}", IFI_Boarder.Width);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("Height: {0}", IFI_Boarder.Height);
                outputFile.Write(Environment.NewLine);


                outputFile.Write("Panel/Entities Values:");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("======================");
                outputFile.Write(Environment.NewLine);


                int count2 = 0;
                foreach (var x in PanelList)
                {
                    outputFile.Write("Panel Number {0}: ", count2);
                    outputFile.Write(Environment.NewLine);

                    outputFile.Write("X value: {0}", x.Xvalue.ToString());
                    outputFile.Write(Environment.NewLine);

                    outputFile.Write("Y Value: {0} ", x.Yvalue.ToString());
                    outputFile.Write(Environment.NewLine);

                    outputFile.Write("Center Value: {0}", x.Center.ToString());
                    outputFile.Write(Environment.NewLine);

                    outputFile.Write("Panel NE_Zone: {0}", x.NE_Zone.ToString());
                    outputFile.Write(Environment.NewLine);

                    outputFile.Write("neighborhood panels: ", x.NeighborHood.ToString());
                    outputFile.Write(Environment.NewLine);


                    count2 += 1;
                }

                outputFile.Write("IFI Corners: ");
                outputFile.Write(Environment.NewLine);

                outputFile.Write("North East Corner: {0}", perm.NE_corner);
                outputFile.Write(Environment.NewLine);

                outputFile.Write("North west Corner: {0}", perm.NW_corner);
                outputFile.Write(Environment.NewLine);
                
            }


        }
    
        private void PrintpermData()
        {
            Console.WriteLine("perm SECTION VALUES");
            Console.WriteLine("====================");
            Console.WriteLine("Corner 1: {0} ", p_perm.Corner1);
            Console.WriteLine("Corner 2: {0} ", p_perm.Corner2);
            Console.WriteLine("Corner 3: {0} ", p_perm.Corner3);
            Console.WriteLine("Corner 4: {0} ", p_perm.Corner4);
            Console.WriteLine("Center : {0}", p_perm.Center);
            Console.WriteLine("perm Dimensions: ");
            Console.WriteLine("==================");
            Console.WriteLine("Width: {0}", p_perm.Width);
            Console.WriteLine("Height: {0}", p_perm.Height);


            Console.ReadKey();
            Console.WriteLine("Press Enter to Continue: ");
            
            return; 
        }
        private void PrintIFIData()
        {
            Console.WriteLine("IFI Values:");
            Console.WriteLine("============");
            Console.WriteLine("Corner 1: {0}", IFI_Boarder.Corner1);
            Console.WriteLine("Corner 2: {0}", IFI_Boarder.Corner2);
            Console.WriteLine("Corner 3: {0}", IFI_Boarder.Corner3);
            Console.WriteLine("Corner 4: {0}", IFI_Boarder.Corner4);
            Console.WriteLine("Press Enter to Continue: ");
            Console.WriteLine("IFI Dimensions: ");
            Console.WriteLine("==================");
            Console.WriteLine("Width: {0}", IFI_Boarder.Width);
            Console.WriteLine("Height: {0}", IFI_Boarder.Height);


            Console.WriteLine("Press Enter to Continue: ");
            Console.ReadKey();
            PrintIFICorners(IFI_Boarder);
            Write_to_file(IFI_Boarder); 


            return; 
        }
        private void PrintPanelData()
        {
            Console.WriteLine("Panel/Entities Values:");
            Console.WriteLine("======================");
            foreach (var x in PanelList)
            {
                Console.WriteLine("Panel Number {0}: ", x.PanelID);
                Console.WriteLine("X value: {0}", x.Xvalue.ToString());
                Console.WriteLine("Y Value: {0} ", x.Yvalue.ToString());
                Console.WriteLine("Center Value: {0}", x.Center.ToString());
                Console.WriteLine("North East Zone: {0}", x.NE_Zone.ToString());
                Console.WriteLine("North West Zone: {0}", x.NW_Zone.ToString());
                Console.WriteLine("Neighbor List: ");
                Console.WriteLine("=================");
                foreach( var neighbor in x.NeighborHood)
                {
                    Console.WriteLine("Neighbor ID: {0} ", neighbor.PanelID); 
                }
                Console.WriteLine("=================");
                Console.WriteLine("\n");

            }
           
            Console.WriteLine("Press Enter to Continue: ");
            Console.ReadKey();


            return;
        }
        private void PrintIFICorners(IFI_Perimeter perm)
            {
            Console.WriteLine("IFI Corners: ");
            Console.WriteLine("North East Corner: {0}", perm.NE_corner);
            Console.WriteLine("North west Corner: {0}", perm.NW_corner);
            Console.WriteLine("Press Enter to Continue: ");
            Console.ReadKey();

        }
        

        IFI_Perimeter p_perm = new IFI_Perimeter();

        IFI_Perimeter IFI_Boarder = new IFI_Perimeter();

        public List<PanelBase> PanelBaseList = new List<PanelBase>();

        public List<Panel> PanelList = new List<Panel>();
        public class PanelBase
        {
            public double Xvalue;
            public double Yvalue;
            public Tuple<double, double> Center = new Tuple<double, double>(0, 0);
            public int PanelID;
            public int EdgeID;
            public int LoadShare;
            public double LoadValue;
            public double NE_Zone = 0;

        }


        //5 and 9 (n) value check 
        // Neighboring lift modules 5 
        // Neighboring sliding modules 9
        //KB NOTE: (n) should be the total number across the neighbor array, number to each side should be (n-1)/2 and should include 0 for base module


        public class Panel
        {
            public int PanelID; 

            public Tuple<double, double> Corner1;
            public Tuple<double, double> Corner2;
            public Tuple<double, double> Corner3;
            public Tuple<double, double> Corner4;

            public double Xvalue;
            public double Yvalue; 

            public double Height;
            public double Width;

            public Tuple<double, double> Center = new Tuple<double, double>(0, 0);

            public List<PanelBase> PanelBases = new List<PanelBase>();
            public List<Panel> NeighborHood = new List<Panel>(); 

            public double NE_Zone = 0;
            public double NW_Zone = 0;

            public int EdgeValue; 
            // 0
            // 1 
            // 2 
            // 3 
            // 4 
            // 5 
            // 6 
            // 7 
            // 8 
            // 9 


        }

        public class IFI_Perimeter
        {
            public Tuple<double, double> Corner1;
            public Tuple<double, double> Corner2;
            public Tuple<double, double> Corner3;
            public Tuple<double, double> Corner4;
            public Tuple<double, double> Center = new Tuple<double, double>(0, 0);
            public double Height;
            public double Width;
            public Tuple<double, double> NE_corner = new Tuple<double, double>(0, 0);
            public Tuple<double, double> NW_corner = new Tuple<double, double>(0, 0);
           
        }

        /// <summary>
        /// Function to organize corners of each perm 
        /// c1 = NW corner 
        /// c2 = NE corner 
        /// c3 = SW corner 
        /// c4 = SE corner 
        /// </summary>
        
        private void SetCorners(IFI_Perimeter perm)
        {
            List<Tuple<double,double>>corner_list = new List<Tuple<double, double>>();
            corner_list.Add(perm.Corner1);
            corner_list.Add(perm.Corner2);
            corner_list.Add(perm.Corner3);
            corner_list.Add(perm.Corner4);
            var max_x = corner_list[0].Item1;
            var max_y = corner_list[0].Item2;
            var min_x = corner_list[0].Item1;
            foreach( var x in corner_list )
            {
                if(x.Item1 >= max_x )
                {
                    max_x = x.Item1;

                }
                if(x.Item2 >= max_y)
                {
                    max_y = x.Item2;
                }
                if(x.Item1 <= min_x)
                {
                    min_x = x.Item1; 
                }

            }
            if((perm.Corner1.Item1 == max_x) && (perm.Corner1.Item2 == max_y))
            {
                perm.NW_corner = perm.Corner1; 

            }
            else if ((perm.Corner2.Item1 == max_x) && (perm.Corner2.Item2 == max_y))
            {
                perm.NW_corner = perm.Corner2;
            }
            else if ((perm.Corner3.Item1 == max_x) && (perm.Corner3.Item2 == max_y))
            {
                perm.NW_corner = perm.Corner3;
            }
            else
            {
                perm.NW_corner = perm.Corner4;
            }

            if ((perm.Corner1.Item1 == min_x) && (perm.Corner1.Item2 == max_y))
            {
                perm.NE_corner = perm.Corner1;

            }
            else if ((perm.Corner2.Item1 == min_x) && (perm.Corner2.Item2 == max_y))
            {
                perm.NE_corner = perm.Corner2;
            }
            else if ((perm.Corner3.Item1 == min_x) && (perm.Corner3.Item2 == max_y))
            {
                perm.NE_corner = perm.Corner3;
            }
            else
            {
                perm.NE_corner = perm.Corner4;
            }

            return;
            
        }
        
        private void  SetZones()
        {
           

            foreach( var x   in PanelList)
            {
               
                if (((Math.Abs(IFI_Boarder.NW_corner.Item1 - x.Center.Item1)) < (787.402) && (Math.Abs(IFI_Boarder.NW_corner.Item2 - x.Center.Item2) < 787.402)))

                    x.NW_Zone = 1;


                else if ((Math.Abs(IFI_Boarder.NW_corner.Item1 - x.Center.Item1) < 787.402) && (Math.Abs(IFI_Boarder.NW_corner.Item2 - x.Center.Item2) > 787.402))
                                                            
                    x.NW_Zone = 2;                             
                                                            
                                                              
                else if (Math.Abs(IFI_Boarder.NW_corner.Item1  - x.Center.Item1) < 1574.804)
                                                              
                    x.NW_Zone = 3;                               
                                                              
                                                                 
                else if (Math.Abs(IFI_Boarder.NW_corner.Item1  - x.Center.Item1) < 2362.206)
                                                           
                    x.NW_Zone = 4;                            
                                                              
                else

                    x.NW_Zone = 5;
                if ((Math.Abs(IFI_Boarder.NE_corner.Item1  - x.Center.Item1) < 787.402) && (Math.Abs(IFI_Boarder.NE_corner.Item2 -  x.Center.Item2) < 787.402))

                    x.NE_Zone = 1;


                else if ((Math.Abs(IFI_Boarder.NE_corner.Item1 - x.Center.Item1) < 787.402) && (Math.Abs(IFI_Boarder.NE_corner.Item2 - x.Center.Item2) > 787.402))

                    x.NE_Zone = 2;


                else if (Math.Abs(IFI_Boarder.NE_corner.Item1 -   x.Center.Item1) < 1574.804)

                    x.NE_Zone = 3;


                else if (Math.Abs(IFI_Boarder.NE_corner.Item1 -  x.Center.Item1) < 2362.206)

                    x.NE_Zone = 4;

                else

                    x.NE_Zone = 5;

            }

        }

        private void CalculateNeighbors()
        {
            Console.WriteLine("Input (N) radii that should be checked: ");
            string input_string = Console.ReadLine();
            int input_n = 0; 
            if (string.IsNullOrEmpty(input_string))
            {
                input_n = 2;
                 
            }
            else
            {
                input_n = Convert.ToInt32(input_string);

            }

            foreach ( var panel in PanelList)
            {
                var x_start = panel.Center.Item1;
                var y_start = panel.Center.Item2;
                var neighborhood = GenerateNeighborhood(input_n, x_start, y_start);



                
                foreach ( var neighbor in neighborhood)
                {
                    foreach ( var x in PanelList)
                    {

                      
                        if ( (Math.Abs(neighbor.Item1 - x.Center.Item1) <= .5) && (Math.Abs(neighbor.Item2 - x.Center.Item2) <= .5))
                             {
                                 panel.NeighborHood.Add(x);
                            
                              }
                    }
                }
            }

          

        }
        
        private List<Tuple<double,double>> GenerateNeighborhood(int input_n, double x_start,double  y_start)
        {
            
            List<Tuple<double, double>> neighborhood = new List<Tuple<double, double>>();
                

            for (int x = 0; x <= input_n; x++ )
            {          
                for (int y = 0; y <= input_n; y++ )
                { 
                    for (int i = -1; i <= 1; i += 2)
                    {
                        if (x.Equals(0))
                        i = 1;
                        
                        
                        for (int j = -1; j <= 1; j += 2)
                        {
                            if (y.Equals(0))
                            j = 1;
                            

                           Tuple<double, double> temp_neighbor = new Tuple<double, double>(x_start + (0.5 + p_perm.Width) * i * x, y_start + (17.494 + p_perm.Height) * j * y);
                           neighborhood.Add(temp_neighbor);
                        }
                        
                    }
                }
            }
            
            return neighborhood; 

        }
        
        private IFI_Perimeter CalculateCenter(IFI_Perimeter perm)
        {
            double x1, x2, y1, y2;
            if(!(perm.Corner1.Item1.Equals(perm.Corner2.Item1)) && !(perm.Corner1.Item2.Equals(perm.Corner2.Item2)))
            {
                x1 = perm.Corner1.Item1;
                x2 = perm.Corner2.Item1;

                y1 = perm.Corner1.Item2;
                y2 = perm.Corner2.Item2;

            }

            else if (!(perm.Corner1.Item1.Equals(perm.Corner3.Item1)) && !(perm.Corner1.Item2.Equals(perm.Corner3.Item2)))
           
            //Corrected 

            {
                x1 = perm.Corner1.Item1;
                x2 = perm.Corner3.Item1;

                y1 = perm.Corner1.Item2;
                y2 = perm.Corner3.Item2;

            }
            else
            {
                 x1 = perm.Corner1.Item1;
                 x2 = perm.Corner4.Item1;

                 y1 = perm.Corner1.Item2;
                 y2 = perm.Corner4.Item2;

            }

            var Width = x2 - x1;
            var Height = y2 - y1;
            var x0 = x2;
            var y0 = y2;
            //KB NOTE: Extra variables added to identify fixed corner (NE corner) and then to be used in finding center consistently.
            if (Width < 0)
            {
                Width = Width * -1;
                x0 = x1; 
            }
            if (Height < 0 )
            {
                Height = Height * -1;
                y0 = y1;
            }


            // KB NOTE: changed perm.Center so that it is always calculated from NE corner (largest x and largest y in block)
            perm.Center = new Tuple<double, double>((x0 - (Width / 2)), (y0 - (Height / 2)));
            perm.Height = Height;
            perm.Width = Width;

            return perm; 
            
        }
        
        private void CalculatePanelCenter()
        {
            foreach (var panel in PanelList)
            {
                panel.Center = new Tuple<double, double>((panel.Xvalue + (p_perm.Center.Item1)), (panel.Yvalue + p_perm.Center.Item2));
                
            }
        }
       
        //private double ConvertToDouble(string s)
        //{
        //    char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
        //    double result = 0;
        //    try
        //    {
        //        if (s != null)
        //            if (!s.Contains(","))
        //                result = double.Parse(s, CultureInfo.InvariantCulture);
        //            else
        //                result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
        //    }
        //    catch (Exception e)
        //    {
        //        try
        //        {
        //            result = Convert.ToDouble(s);
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
        //            }
        //            catch
        //            {
        //                throw new Exception("Wrong string-to-double format");
        //            }
        //        }
        //    }
        //    return result;
        //}

        private string FileName;

        public DxfParser(string filename)
        {
            FileName = filename;
        }
        private IFI_Perimeter  Parseperims(int start, int end)
        {
            string[] perims_section = new string[end - start];
            Array.Copy(lines, start, perims_section, 0, end - start);
            bool perm_name_condition = false;
            bool entity_condition = false;
            int index = 0; 
            
            foreach( string x in perims_section)
                {
                  if (x.Contains("JA 320W 10DEG"))
                     {
                       perm_name_condition = true; 
                    }
                  if(perm_name_condition)
                    {
                        if( x.Contains("AcDbPolyline"))
                        {
                       
                        List<Double> temp_list = new List<Double>();
                        
                        for (int i = 8; i<= 22; i+=2)
                        {
                            temp_list.Add(Convert.ToDouble(perims_section[index +  i].Trim()));
                        }

                        p_perm.Corner1 = new Tuple<double,double>(temp_list[0], temp_list[1]);
                        p_perm.Corner2 = new Tuple<double, double>(temp_list[2], temp_list[3]);
                        p_perm.Corner3 = new Tuple<double, double>(temp_list[4], temp_list[5]);
                        p_perm.Corner4 = new Tuple<double, double>(temp_list[6], temp_list[7]);
                        Console.WriteLine(p_perm.Corner1);
                        Console.WriteLine(p_perm.Corner2);
                        Console.WriteLine(p_perm.Corner3);
                        Console.WriteLine(p_perm.Corner4);
                        Console.ReadKey();

                        var perm_w_center = CalculateCenter(p_perm); 
                        
                        break;

                    }

                }
                index += 1; 
            }
            
            return p_perm; 


        }
        private void ParseEntities(int start, int end)
        {
            string[] entites_section = new string[end - start];
            Array.Copy(lines, start, entites_section, 0, end - start);
            int index = 0;
            int panel_count = 1;

            foreach (string x in entites_section)
            {
               

                if ( x.Contains("AcDbBlockReference") && ( entites_section[index + 2].Contains("JA 320W 10DEG")))
                {

                    List<double> temp_list = new List<double>();
                    for (int i = 4; i <= 8; i += 2)
                    {
                        temp_list.Add(Convert.ToDouble(entites_section[index + i].Trim()));

                    }
                    Panel temp_base = new Panel();
                    temp_base.Xvalue = temp_list[0];
                    temp_base.Yvalue = temp_list[1];
                    temp_base.PanelID = panel_count; 
                    PanelList.Add(temp_base);
                    Console.WriteLine(panel_count);
                    panel_count = panel_count + 1; 


                }
                    if (x.Contains("IFI"))
                {
                    List<Double> temp_list = new List<Double>();
                    for (int i = 0; i < 16; i += 2)
                    {
                        temp_list.Add(Convert.ToDouble(entites_section[index + 10 + i].Trim()));

                    }

                    IFI_Boarder.Corner1 = new Tuple<double, double>(temp_list[0], temp_list[1]);
                    IFI_Boarder.Corner2 = new Tuple<double, double>(temp_list[2], temp_list[3]);
                    IFI_Boarder.Corner3 = new Tuple<double, double>(temp_list[4], temp_list[5]);
                    IFI_Boarder.Corner4 = new Tuple<double, double>(temp_list[6], temp_list[7]);

                }
                index += 1; 

            }

            CalculatePanelCenter();
            CalculateCenter(IFI_Boarder);
            SetCorners(IFI_Boarder);
            SetZones();
            CalculateNeighbors(); 
            
        }

        public void ParseFile()
        {
            //string text = File.ReadAllText(@"C: \Users\Owner\Desktop\EcoLibriumSolar\BallastCalculator\BallastCalculator\sw315w & bases.dxf");
            //Console.WriteLine("Contents of WriteText.txt = {0}", text);
            //Console.ReadLine();

            //string[] lines2 = File.ReadAllLines(@"C:\Users\Owner\Desktop\EcoLibriumSolar\BallastCalculator\BallastCalculator\E3 ECOFEET - one ecofoot base.dxf");
            //string[] lines3 = File.ReadAllLines(@"C: \Users\Owner\Desktop\EcoLibriumSolar\BallastCalculator\BallastCalculator\sw315w 10deg.dxf");
            int index = 0;
            int perm_start = 0;
            int perm_end = 0;
            int entity_start = 0;
            int entity_end = 0;
            foreach (string x in lines)
            {


                if (x.Contains("BLOCKS"))
                {
                    perm_start = index;

                }
                if (perm_start != 0)
                {
                    if (x.Contains("ENDSEC"))
                    {
                        perm_end = index;
                    }
                }

                if (x.Contains("ENTITIES"))
                {
                    entity_start = index;

                }
                if (entity_start != 0)
                {
                    if (x.Contains("ENDSEC"))
                    {
                        entity_end = index;
                    }
                }

                index += 1;
            }
            

            Parseperims(perm_start, perm_end);
            ParseEntities(entity_start, entity_end); 
           
     
        }

    }
}
    
