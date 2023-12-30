using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonvertorTlak.Enums;

namespace KonvertorTlak.Units
{
    //Convert value from the Bar to others
    internal class BarUnit : Convertor
    {
        public override double Convert(double value, Unit unitValue, ISU unitISU)
        {
            switch (unitValue)
            {
                case Unit.Atm:
                    value = ConvertToPa(value);
                    break;
                case Unit.Pa:
                    value = ConvertToAtm(value);
                    break;
                case Unit.Bar:
                    break;
                default:
                    throw new Exception("Unit conversion is not defined");
            }

            return ConvertISU(value, unitISU);
        }

        private double ConvertToPa(double value)
        {
            return RoundUp(value * 100000);
        }

        private double ConvertToAtm(double value)
        {
            return RoundUp(value / 1.01325);
        }
    }
}
