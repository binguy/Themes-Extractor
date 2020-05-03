using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ThemesOutputer.TextMakerPlus;

namespace ThemesOutputer
{
    public class TextMakerTheme
    {
        public static void TextThemes(List<string> yeetdirs, string tpath)
        {
            try { 
            
            foreach (string yeey in yeetdirs)
            {
                var themes = new List<string>();
                var names = new List<string>();
                    string text = Teeext(yeey);
                        if(text !=null) {
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
                    //For loop for all themes found in level. So for loop loops the amount of themes level.lsb had. 
                    for (int i = 0; i < names.Count; i++)
                    {

                        themes.Add(names[i]);
                        if (i == names.Count - 1)
                        {
                            themes[i] = themes[i].Remove(themes[i].LastIndexOf("]")); //The last theme is dick so we must calm it down
                        }
                        int idx = names[i].IndexOf("name");
                        int idxa = names[i].IndexOf("gui");
                        if (idxa == -1)
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
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
