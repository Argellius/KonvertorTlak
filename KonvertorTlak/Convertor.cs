using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonvertorTlak.Enums;

namespace KonvertorTlak
{
    internal abstract class Convertor
    {
        public abstract double Convert(double value, Unit unitValue, ISU unit);

        protected double RoundUp(double value)
        {
            return Math.Round(value, 5);

        }

        public double ConvertISU(double value, ISU unit)
        {
            switch (unit)
            {
                case ISU.None:
                    return value;
                case ISU.Mili: 
                    return value / 1000;
                case ISU.Mikro:
                    return value / 1000000;
                default: return value;
            }
        }

        public double ConvertToNoneISU(double value, ISU unit)
        {
            switch (unit)
            {
                case ISU.None:
                    return value;
                case ISU.Mili:
                    return value * 1000;
                case ISU.Mikro:
                    return value * 1000000;
                default: return value;
            }
        }
    }
}
