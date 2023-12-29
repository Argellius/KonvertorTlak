using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonvertorTlak
{
    //Convert value from the Pascal to others
    internal class PascalUnit : Convertor
    {
        public override double Convert(double value, Unit unitValue)
        {
            switch (unitValue)
            {
                case Unit.Atm:
                    return RoundUp(value / 101325);
                case Unit.Pa:
                    return value;
                case Unit.Bar:
                    return RoundUp(value / 100000);
                default:
                    throw new Exception("Unit conversion is not defined");
            }
        }


    }
}
