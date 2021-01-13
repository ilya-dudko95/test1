using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            FileInfo fileInfo = new FileInfo($@"C:\C#\test1\{date}.txt");
            string text = "";
            Console.WriteLine("Enter text line and press Enter for new line. Press Ctrl + S to Save file");
            while (true)
            {
                var charValue = Console.ReadKey();
                switch (charValue.Key)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        text += "\r\n";
                        break;

                    case ConsoleKey.Escape:
                        return;
                        break;

                    case ConsoleKey.S:
                        if ((charValue.Modifiers.HasFlag(ConsoleModifiers.Control)))
                        {
                            Console.Write("");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            File.AppendAllText($@"C:\C#\test1\{date}.txt", text);
                            Console.WriteLine($"File successfully saved. {fileInfo.Length} bytes");
                        }
                        break;

                    default:
                        text += charValue.KeyChar;
                        break;
                }
            }
        }
    }
}

