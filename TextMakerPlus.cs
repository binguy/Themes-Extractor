using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThemesOutputer
{
    class TextMakerPlus
    {
        public static string Teeext(string yeey)
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
                return text;
            }
            else
            {
                return null;

            }
        }
    }
}
