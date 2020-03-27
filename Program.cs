using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var names = new List<string>();
            var themes = new List<string>();
            var foundIndexes = new List<int>();
            bool checker = false;
                string path;
            do {
                try
                {
                    Console.WriteLine("Please write a path to level.lsb which you want to use for Extracting the themes");
                    path = Console.ReadLine();

                    if (path.Contains("\""))
                    {
                        path = path.Remove(path.LastIndexOf("\""));
                        path = path.Substring(path.IndexOf("\"")+1);
                    }
                    if (path.Contains("level.lsb"))
                    {
                        path = path.Remove(path.LastIndexOf("\\level.lsb"));
                    }
                var fileStream = new FileStream(@$"{path}\level.lsb", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        text = line;
                    }
                }

            int idx = text.IndexOf("themes");
            int idxa = text.IndexOf("checkpoints");
            text = text.Remove(idxa - 1);
            text = text.Substring(idx + 9);
            Console.WriteLine($"The index of themes: {idx}, and index of he: {idxa}");
            for (int i = text.IndexOf('{'); i > -1; i = text.IndexOf('{', i + 1))
            {
                //for loop end when i=-1 ('{' not found)
                foundIndexes.Add(i);
            }
            for (int a = 1; a < foundIndexes.Count; a++)
            {
                foundIndexes[a] = foundIndexes[a] + heey;
                heey = heey + 1;
                text = text.Insert(foundIndexes[a], "\n");

            }
            using (StringReader reader = new StringReader(text))
            {
                string line;
                while((line = reader.ReadLine()) !=null)
                {
                    line = line.Remove(line.LastIndexOf(","));
                    names.Add(line);
                }
            }
            Console.WriteLine("Please write the system path to folder where you want themes to be extracted. without \\ at the end");
            string tpath = Console.ReadLine();
                    if (tpath.Contains("\""))
                    {
                        tpath = tpath.Remove(tpath.LastIndexOf("\""));
                        tpath = tpath.Substring(tpath.IndexOf("\"") + 1);
                    }
                    for (int i = 0; i < names.Count; i++)
                {

                    themes.Add(names[i]);
                    if (i == names.Count - 1)
                    {
                        themes[i] = themes[i].Remove(themes[i].LastIndexOf("]"));
                    }
                    idx = names[i].IndexOf("name");
                    idxa = names[i].IndexOf("gui");
                    names[i] = names[i].Remove(idxa - 3);
                    names[i] = names[i].Substring(idx + 7);
                    string fileName = @$"{tpath}\{names[i]}.lst";
                FileInfo fi = new FileInfo(fileName);
                //Check if file already exists. If yes, delete it.     
                if (fi.Exists)
                {
                    fi.Delete();
                }
                // Create a new file     
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine(themes[i]);
                    Console.WriteLine($"File Created! Name: {names[i]}");
                }
            }
                    checker = true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        } while (checker == false);
            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Do you want to complete this process?\n 1-yes, anything else-no");
            string stfu = Console.ReadLine();
                if (stfu == "1")
            {
                    yeeter = 1;
                }
                else
                {
                    yeeter = 0;
                }
            } while (yeeter == 1);
        }
    }
}
