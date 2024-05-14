using System;

class Program
{
    static void Main()
    {
        
         double epsilon = 0.0001;
         for (double x = 0.2; x <= 1; x += 0.08)
         {
            double sn = 0;
            double y = 0.5 * Math.Log(x);
            for (int n = 0; n <= 10; n++) {
                sn += Math.Pow(((x - 1) / (x + 1)), 2 * n + 1) * 1 / (2 * n + 1);
            }
            
            double buff = (x-1)/(x+1);
            double se = buff;
            int k = 1;
            while (Math.Abs(buff) > epsilon)
            {   
                buff *= Math.Pow(((x - 1) / (x + 1)), 2);
                se += buff * 1 / (2 * k + 1);
                k++;
            }
            Console.WriteLine($"X = {x, 4:f6} || SN = {sn,4:f6} || SE = {se,4:f6}\t || Y = {y,4:f6}");
          }
    }
}