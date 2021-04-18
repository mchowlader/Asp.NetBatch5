using System;

namespace EventExamole3
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscribe subscribe = new Subscribe();
            Calsulation calsulation = new Calsulation();

            calsulation.evMath += new Calsulation.dgCalculation(Subscribe.SubscribeOne);
            calsulation.Sometthing();

            calsulation.evMath -= new Calsulation.dgCalculation(Subscribe.SubscribeOne);
            calsulation.Sometthing();
        }
    }
}
