using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10ClassLib
{
    public class Class : IInit
    {
        public string? Name { get; set; }

        public void Init()
        {
            Name = "ClassName";
        }

        public void RandomInit()
        {
            Name = $"RandomClassName_{new Random().Next(1, 100)}";
        }

        public void Show()
        {
            Console.WriteLine($"Имя: {Name}");
        }
    }
}
