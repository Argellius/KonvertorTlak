using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonvertorTlak
{
    internal abstract class Convertor
    {
        public abstract double Convert(double value, Unit unitValue);

        protected double RoundUp(double value)
        {
            return Math.Round(value, 5);

        }
    }
}
