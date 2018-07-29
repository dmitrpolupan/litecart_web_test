using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litecart_web_test
{
    class Square : Figure
    {
        public int Area { get; set; }

        public Square(int area)
        {
            Area = area;
        }
    }
}
