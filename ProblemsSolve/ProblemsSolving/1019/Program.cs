using System;

namespace _1019
{
    class Program
    {
        static void Main(string[] args)
        {

            while(true)
            {

            var second = Convert.ToInt32(Console.ReadLine());

            var hour = 0;
            var minutes = 0;

            if (second < 60)
            {
                Console.WriteLine($"{hour}:{minutes}:{second}");
               
            }

            else
            {
                if (second / 60 >= 60)
                {
                    minutes = second/60;
                    second = second % 60;

                    if(minutes > 59)
                    {
                        hour = minutes / 60;
                        minutes = minutes % 60;

                        Console.WriteLine($"{hour}:{minutes}:{second}");
                        break;
                    }
                   
                }
               
                if (second / 60 <= 60)
                {
                    minutes = second / 60;
                    second = second % 60;

                    Console.WriteLine($"{hour}:{minutes}:{second}");

                }
            }
        }
    }      
    }
}
