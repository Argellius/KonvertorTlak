using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonvertorTlak.Enums;

namespace KonvertorTlak.Units
{
    //Convert value from the Pascal to others
    internal class PascalUnit : Convertor
    {
        public override double Convert(double value, Unit unitValue, ISU unitISU)
        {
            switch (unitValue)
            {
                case Unit.Atm:
                    value = ConvertToAtm(value);
                    break;
                case Unit.Pa:
                    break;
                case Unit.Bar:
                    value = ConvertToBar(value);
                    break;
                default:
                    throw new Exception("Unit conversion is not defined");
            }

            return ConvertISU(value, unitISU);
        }

        private double ConvertToAtm(double value)
        {
            return RoundUp(value / 101325);
        }

        private double ConvertToBar(double value)
        {
            return RoundUp(value / 100000);
        }


    }
}
