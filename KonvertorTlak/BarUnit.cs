using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonvertorTlak
{
    //Convert value from the Bar to others
    internal class BarUnit : Convertor
    {
        public override double Convert(double value, Unit unitValue)
        {
            switch (unitValue)
            {
                case Unit.Atm:
                    return RoundUp(value / 1.01325);
                case Unit.Pa:
                    return  RoundUp(value * 100000);
                case Unit.Bar:
                    return value;
                default:
                    throw new Exception("Unit conversion is not defined");
            }
        }


    }
}
