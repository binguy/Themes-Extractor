using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ThemesOutputer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            int yeeter = 0;
            // Begin timing.
            do {
            stopwatch.Start();
            string text = "";
            int heey = 0;
            bool checker = false;
                var yeetdirs = new List<string>();
                string path;
            do {
                try
                {
                    Console.WriteLine("Please write a path to level.lsb which you want to use for Extracting the themes.\n or... [REDACTED]");
                    path = Console.ReadLine();
                        Console.WriteLine("Please write the system path to folder where you want themes to be extracted. without \\ at the end");
                        string tpath = Console.ReadLine();
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
                            }catch(Exception e)
                            {
                                Console.WriteLine("The process failed: {0}", e.ToString());
                            }
                        }else
                        {
                            yeetdirs.Add(path);
                        }
                        foreach (string yeey in yeetdirs)
                        {
                            text = "";
                            heey = 0;
                            var themes = new List<string>();
                            var foundIndexes = new List<int>();
                            var names = new List<string>();
                            var fileStream = new FileStream(@$"{yeey}\level.lsb", FileMode.Open, FileAccess.Read);
                            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                            {
                                string line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    //We read the entire level.lsb here
                                    text = line;
                                }
                            }
                            int idx = text.IndexOf("themes");
                            int idxa = text.IndexOf("checkpoints");
                            if (idx != -1)
                                {

                                text = text.Remove(idxa - 1); //Removes some chars to make clear string of theme
                                text = text.Substring(idx + 9); //Removes some chars to make clear string of theme
                                Console.WriteLine($"The index of themes: {idx}, and index of he: {idxa}");
                                for (int i = text.IndexOf('{'); i > -1; i = text.IndexOf('{', i + 1))
                                {
                                    //for loop end when i=-1 ('{' not found)
                                    foundIndexes.Add(i);
                                }
                                for (int a = 1; a < foundIndexes.Count; a++)
                                {
                                    //Something which I do not remember. I might need to call to memory and ask what the fuck is this.
                                    foundIndexes[a] = foundIndexes[a] + heey;
                                    heey = heey + 1;
                                    text = text.Insert(foundIndexes[a], "\n");

                                }
                                using (StringReader reader = new StringReader(text))
                                {
                                    string line;
                                    while ((line = reader.ReadLine()) != null)
                                    {
                                        //Still can't remember what the heck this thing is doing with my program
                                        if (line != " ") {
                                            line = line.Remove(line.LastIndexOf(","));
                                            names.Add(line);
                                        }
                                    }
                                }
                                //Path to folder where Themes will drop their bodies
                                if (tpath.Contains("\""))
                                {
                                    tpath = tpath.Remove(tpath.LastIndexOf("\""));
                                    tpath = tpath.Substring(tpath.IndexOf("\"") + 1);
                                }
                                //For loop for all themes found in level. So for loop loops the amount of themes level.lsb had. 
                                for (int i = 0; i < names.Count; i++)
                                {

                                    themes.Add(names[i]);
                                    if (i == names.Count - 1)
                                    {
                                        themes[i] = themes[i].Remove(themes[i].LastIndexOf("]")); //The last theme is dick so we must calm it down
                                    }
                                    idx = names[i].IndexOf("name");
                                    idxa = names[i].IndexOf("gui");
                                    if(idxa == -1)
                                    {
                                        idxa = names[i].IndexOf("bg");
                                    }
                                    names[i] = names[i].Remove(idxa - 3);
                                    names[i] = names[i].Substring(idx + 7);
                                    string fileName = @$"{tpath}\{names[i]}.lst"; //Completed path with name and path
                                    FileInfo fi = new FileInfo(fileName);
                                    //Check if file already exists. If yes, delete it.     
                                    if (fi.Exists)
                                    {
                                        //if the same theme exists in folder.
                                        fi.Delete();
                                    }
                                    // Create a new file     
                                    using (StreamWriter sw = fi.CreateText())
                                    {

                                        sw.WriteLine(themes[i]);//It writes theme string into the file in one line. might update later so there will be /n everywhere
                                        Console.WriteLine($"File Created! Name: {names[i]}");//Tells us that File created without any errors
                                    }
                                }
                            }
                        }
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
