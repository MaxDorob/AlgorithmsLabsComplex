using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Car
    {
        public string Model { get; set; }
        public string Number { get; set; }
        public override string ToString()
        {
            return Model+Number;
        }
    }
}
