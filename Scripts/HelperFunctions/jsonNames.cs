using Godot;
using System;
using static System.Text.Json.JsonSerializer;
using System.Text;
using System.IO;

namespace jsonNames
{
    public class jsonNamesInterface
    {
        public string[] firstNames { get; set; }
        public string[] lastNames { get; set; }
    }

    public class jsonNames
    {
        public string returnName()
        {
            string jsonString = File.ReadAllText("lib/Content/Names.json");
            jsonNamesInterface charName = Deserialize<jsonNamesInterface>(jsonString);

            return charName.firstNames[new Random().Next(0, charName.firstNames.Length)]
                + " "
                + charName.lastNames[new Random().Next(0, charName.lastNames.Length)];
        }
    }
}
