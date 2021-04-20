using System;
using System.IO;
using System.Threading;

namespace ThreadLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var Program = new Program();

            Thread thread1 = new Thread(new ThreadStart(Program.WriteFileMethod));
            Thread thread2 = new Thread(new ThreadStart(Program.WriteFileMethod));
            thread1.Start();
            thread2.Start();
        }

        public static void WriteFileMethod()
        {
            var text = "Hi Akkas";
            var path = @"D:\DevSkill\dotNet\Code\Asp.NetBatch5\DotNetCode\ThreadLock\file.txt";
            lock(path)
            {
                File.WriteAllText(path, text);
            }
        }
    }
}
