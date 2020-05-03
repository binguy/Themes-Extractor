using System;
using System.Collections.Generic;
using System.Text;

namespace ThemesOutputer
{
    public class TPathHelper
    {
        public static string TPath()
        {

            Console.WriteLine("Please write the system path to folder where you want themes to be extracted. without \\ at the end");
            string tpath = Console.ReadLine();
            //Path to folder where Themes will drop their bodies
            if (tpath.Contains("\""))
            {
                tpath = tpath.Remove(tpath.LastIndexOf("\""));
                tpath = tpath.Substring(tpath.IndexOf("\"") + 1);
            }
            return tpath;
        }
    }
}
