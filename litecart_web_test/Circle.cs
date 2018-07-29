using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litecart_web_test
{
    class Circle : Figure
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }
    }
}
