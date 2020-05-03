using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static ThemesOutputer.ThemeHelper;
using static ThemesOutputer.TPathHelper;
using static ThemesOutputer.TextMakerTheme;

namespace ThemesOutputer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            int yeeter;
            //string prefabLast = "} ]}} ]} ]";
            // Begin timing.
            do {
            stopwatch.Start();
            bool checker = false;
            do {
                try
                {
                        TextThemes(Path(), TPath());
                       
                        checker = true;//No errors = freedom
            }
            catch (Exception Ex)
            {
                        //If you will screw something you go there.
                Console.WriteLine(Ex.ToString());
            }
        } while (checker == false);
            // Stop timing.
            stopwatch.Stop();//Timer because I wanted to say C# is 100000000x faster then Java.

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Do you want to repeat process?\n 1-yes, anything else-no"); //Choice = red pill or blue pill.
            string stfu = Console.ReadLine();
                if (stfu == "1")
            {
                    yeeter = 1;
                }
                else
                {
                    yeeter = 0;
                }
            } while (yeeter == 1);//yeet
        }
    }
}
