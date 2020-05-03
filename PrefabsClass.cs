using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ThemesOutputer
{
    public class PrefabsClass
    {

        public static void Preeeefabs(List<string> yeetdirs, string tpath)
        {
            try
            {
                var h = new List<string> { "\\", "/", ":", "*", "?", "\"", ">", "<", "|"};
                foreach (string yeey in yeetdirs)
                {
                    var themes = new List<string>();
                    var names = new List<string>();
                    string text = Yeeeeetext(yeey);
                    if (text != null)
                    {
                        using (StringReader reader = new StringReader(text))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                //Still can't remember what the heck this thing is doing with my program
                                if (line != " ")
                                {
                                    line = line.Remove(line.LastIndexOf(","));
                                    names.Add(line);
                                }
                            }
                        }
                        //For loop for all themes found in level. So for loop loops the amount of prefabs level.lsb had. 
                        for (int i = 0; i < names.Count; i++)
                        {

                            themes.Add(names[i]);
                            if (i == names.Count - 1)
                            {
                                themes[i] = themes[i].Remove(themes[i].LastIndexOf("]")); //The last theme is dick so we must calm it down
                            }
                            int idx = names[i].IndexOf("name");
                            int idxa = names[i].IndexOf("type");
                            names[i] = names[i].Remove(idxa - 3);
                            names[i] = names[i].Substring(idx + 7);
                            for(int a=0;a<h.Count; a++)
                            {
                                names[i] = names[i].Replace(h[a], "");
                            }
                            string fileName = @$"{tpath}\{names[i]}.lsp"; //Completed path with name and path
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
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        public static List<string> PathP()
        {
            string path;
            var yeetdirs = new List<string>();
            try
            {
                Console.WriteLine("Please write a path to level.lsb which you want to use for Extracting the prefabs.\n or... [REDACTED]");
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
        public static string TPathP()
        {
            Console.WriteLine("Please write the system path to folder where you want prefabs to be extracted. without \\ at the end");
            string tpath = Console.ReadLine();
            //Path to folder where Themes will drop their bodies
            if (tpath.Contains("\""))
            {
                tpath = tpath.Remove(tpath.LastIndexOf("\""));
                tpath = tpath.Substring(tpath.IndexOf("\"") + 1);
            }
            return tpath;
        }
        public static string Yeeeeetext(string yeey)
        {
            int heey = 0;
            string text = "";
            var foundIndexes = new List<int>();
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
            int idx = text.IndexOf("prefabs");
            int idxa = text.IndexOf("themes");
            if (idx != -1)
            {

                text = text.Remove(idxa - 1); //Removes some chars to make clear string of theme
                text = text.Substring(idx + 10); //Removes some chars to make clear string of theme
                Console.WriteLine($"The index of themes: {idx}, and index of he: {idxa}");
                for (int i = text.IndexOf("{\"n"); i > -1; i = text.IndexOf("{\"n", i + 1))
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
                return text;
            }
            else
            {
                return null;

            }
        }
    }
}
