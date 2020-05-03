using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ThemesOutputer
{
    public class ThemeHelper
    {
        public static List<string> Path()
        {
            string path;
            var yeetdirs = new List<string>();
            try
            {
                Console.WriteLine("Please write a path to level.lsb which you want to use for Extracting the themes.\n or... [REDACTED]");
                path = Console.ReadLine();
                if (path.Contains("\""))
                {
                    //This removes the "" symbols from the path. That happens when you drag folder/file in Console - Path will look like "C:\System32\Secrets\Pirate.lsb" and that code removes " "
                    path = path.Remove(path.LastIndexOf("\""));
                    path = path.Substring(path.IndexOf("\"") + 1);
                }
                if (path.Contains("level.lsb"))
                {
                    //If user just dragged the level level.lsb so this path will include the level.lsb at the end. Due to conflits(User might not include the level.lsb at the end i had to remove this to fix conflict
                    path = path.Remove(path.LastIndexOf("\\level.lsb"));
                }
                if (path == "yeet")
                {
                    try
                    {
                        Console.WriteLine("Please write the Disk Drive on which you have installed Steam");
                        string DiskDrive = Console.ReadLine();
                        string[] h = Directory.GetDirectories($@"{DiskDrive}:\Program Files (x86)\Steam\steamapps\workshop\content\440310\");
                        yeetdirs = h.ToList();
                        Console.WriteLine($"The number of directories(levels) in your workshop is: {yeetdirs.Count}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                }
                else
                {
                    yeetdirs.Add(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
                    return yeetdirs;
        }
    }
}
