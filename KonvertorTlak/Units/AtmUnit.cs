using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using KonvertorTlak.Enums;

namespace KonvertorTlak.Units
{
    //Convert value from the Atm to others
    internal class AtmUnit : Convertor
    {
        public override double Convert(double value, Unit unitValue, ISU unitISU)
        {

            switch (unitValue)
            {
                case Unit.Atm:
                    break;
                case Unit.Pa:
                    value = ConvertToPa(value);
                    break;
                case Unit.Bar:
                    value = ConvertToBar(value);
                    break;
                default:
                    throw new Exception("Unit conversion is not defined");
            }

            return ConvertISU(value, unitISU);
        }


        private double ConvertToPa(double value)
        {
            return RoundUp(value * 101325);
        }

        private double ConvertToBar(double value)
        {
            return RoundUp(value * 1.01325);
        }
    }
}
