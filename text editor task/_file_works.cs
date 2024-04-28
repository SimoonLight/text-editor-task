using System.IO;

namespace text_editor_task
{
    public class _file_works
    {
        public static void Write_text(string file_name, string text)
        {
            if (File.Exists($"{file_name}.txt"))
            {
                File.WriteAllText($"{file_name}", text);
            }
        }

        public static string Read_text(string file_name)
        {
            if (File.Exists($"{file_name}.txt"))
            {
                return File.ReadAllText($"{file_name}.txt");
            }
            else
            {
                return "";
            }
        }
    }
}
