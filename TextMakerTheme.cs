using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThemesOutputer
{
    public class TextMakerTheme
    {
        public static void TextThemes(List<string> yeetdirs, string tpath)
        {
            try { 
            
            foreach (string yeey in yeetdirs)
            {
                string text = "";
                int heey = 0;
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
                        idx = names[i].IndexOf("name");
                        idxa = names[i].IndexOf("gui");
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
