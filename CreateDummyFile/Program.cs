using System;
using System.IO;

namespace CreateDummyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //argments
            if (args.Length < 2)
            {
                System.Console.WriteLine("Usage:　CreateDummy [file-name] [file-size] ");
                return;
            }

            var name = args[0];
            var size = 0;
            if (int.TryParse(args[1], out size) == false)
            {
                System.Console.WriteLine("数値で入力してください");
                return;
            }

            //write
            using (var stream = new StreamWriter($"./{name}"))
            {
                for (int i = 0; i < size; i++)
                {
                    stream.Write(0x00);
                }
            }

        }
    }
}
