using static System.Net.Mime.MediaTypeNames;

class Program
{   
    static int CheckInputInt(string text)
    {
        int inputValue;
        bool isOk = false;
        do
        {
            Console.Write(text);
            string buf = Console.ReadLine();
            isOk = Int32.TryParse(buf, out inputValue);
            if (!isOk)
                Console.WriteLine("Ошибка. Введенное значение не соотвуствует типу Int.");
        } while (!isOk);
        return inputValue;
    }
    static double CheckInputDouble()
    {
        double inputValue = 0;
        bool isOk = false;
        do
        {
            Console.Write("Введите X = ");
            string buf = Console.ReadLine();
            isOk = Double.TryParse(buf, out inputValue);
            if (!isOk)
            { 
                Console.WriteLine("Ошибка. Введенное значение не соотвуствует типу Double.");
            }
            else 
                if (inputValue == 0)
            {
                Console.WriteLine("Ошибка. Нельзя вычислить.");
            }
        } while (!isOk || inputValue == 0);
        return inputValue;
    }
    static float CheckInputFloat(string text) 
    {
        float inputValue;
        bool isOk = false;
        do
        {
            Console.Write(text);
            string buf = Console.ReadLine();
            isOk = float.TryParse(buf, out inputValue);
            if (!isOk) 
                Console.WriteLine("Ошибка. Введенное значение не соотвуствует типу Float.");
        } while (!isOk);
        return inputValue;
    }
    static void TaskOne()
    {
        int result = 0;
        int m, n;
        double x = 0;
        n = CheckInputInt("Введите N = ");
        m = CheckInputInt("Введите M = ");
        if (m == 1)
        {
            Console.WriteLine("Ошибка. Нельзя вычислить.");
            m = CheckInputInt("Введите M = ");
        }
        else
        {
            result = (n++ / --m);
            result++;
        }
        Console.WriteLine($"m = {m} n = {n} (n++/--m)++ = {result}");
        Console.WriteLine($"m = {m} n = {n} (++m<n--)= {++m < n--}");
        Console.WriteLine($"m = {m} n = {n} (++m<n--)= {--m > ++n}");

        x = CheckInputDouble();
        Console.WriteLine($"x = {x} SQRT(e^x + tg x, 3) + (1/x) = {Math.Cbrt(Math.Pow(Math.E, x) + Math.Tan(x)) + (1 / x)}");
    }
    static void TaskTwo()
    {
        float X1, Y1;

        X1 = CheckInputFloat("Введите координату Х: ");
        Y1 = CheckInputFloat("Введите координату Y: ");
        bool isIncluded = (X1 >= -1 && X1 <= 1 && Y1 >= -1 && Y1 <= 1
            && (Y1 * Y1 + X1 * X1) <= 1 && (Y1 + X1) >= -1);
        if(isIncluded)
        {
            Console.WriteLine($"({X1};{Y1}) - {isIncluded}.");
        }
        else
        {
            Console.WriteLine($"({X1};{Y1}) - {isIncluded}.");
        }
    }
    static void TaskThree()
    {
        double a = 1000, b = 0.0001;

        double dFirstAct = Math.Pow(a+b, 4);
        double dSecondAct = Math.Pow(a, 4) + 6 * Math.Pow(a * b, 2);
        double dThirdAct = dSecondAct + 4 * a * Math.Pow(b,3);
        double dFourAct = dFirstAct - dThirdAct;
        double dFiveAct = Math.Pow(b, 4) + (4 * Math.Pow(a, 3) * b);
        double dSixAct = dFourAct / dFiveAct;

        Console.WriteLine($"Double result = {dSixAct}");

        float A = 1000f, B = 0.0001f;

        //float fFirstAct = MathF.Pow(A + B, 4);
        //float fSecondAct = MathF.Pow(A, 4) + 6 * MathF.Pow(A * B, 2);
        //float fThirdAct = fSecondAct + 4 * A * MathF.Pow(B, 3);
        //float fFourAct = fFirstAct - fThirdAct;
        //float fFiveAct = MathF.Pow(B, 4) + (4 * MathF.Pow(A, 3) * B);
        //float fSixAct = fFourAct / fFiveAct;
        //Console.WriteLine($"Float result = {fSixAct}");

        float fdFirstAct = (float)Math.Pow(a + b, 4);
        float fdSecondAct = (float)(Math.Pow(a, 4) + 6 * Math.Pow(a * b, 2));
        float fdThirdAct = (float)(fdSecondAct + 4 * a * Math.Pow(b, 3));
        float fdFourAct = (float)(fdFirstAct - fdThirdAct);
        float fdFiveAct = (float)(Math.Pow(b, 4) + (4 * Math.Pow(a, 3) * b));
        float fdSixAct = (float)fdFourAct / fdFiveAct;
        Console.WriteLine($"Float result = {fdSixAct}");
    }
    static void Main(string[] args)
    {
        TaskOne();
        /*TaskTwo();*/
        /*TaskThree();*/
    }
} 