using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KonvertorTlak
{
    //Convert value from the Atm to others
    internal class AtmUnit : Convertor
    {
        public override double Convert(double value, Unit unitValue)
        {
            switch (unitValue)
            {
                case Unit.Atm:
                    return value;
                case Unit.Pa:
                    return RoundUp(value * 101325);
                case Unit.Bar:
                    return RoundUp(value * 1.01325);
                default:
                    throw new Exception("Unit conversion is not defined");
            }
        }
    }
}
