using MiniWindowGameLib.Character;
using System.Text.Json;

namespace MiniWindowGameLib.Core
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public class SaveState
    {
        public List<Character.Character> Characters { get; set; }

        public Difficulty Difficulty { get; set; }

        public SaveState()
        {
        }

        public SaveState(
            List<Character.Character> characters,
            Difficulty difficulty)
        {
            Characters = characters;
            Difficulty = difficulty;
        }

        public void Save(string filename)
        {
            string json = JsonSerializer.Serialize(
                this,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText(filename, json);
        }

        public static SaveState? Load(string filename)
        {
            if (!File.Exists(filename))
                return null;

            string json = File.ReadAllText(filename);

            return JsonSerializer.Deserialize<SaveState>(
                json,
                new JsonSerializerOptions()
            );
        }
    }
}