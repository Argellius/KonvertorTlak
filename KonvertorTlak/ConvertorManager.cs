using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonvertorTlak.Enums;
using KonvertorTlak.Units;

namespace KonvertorTlak
{
    internal class ConvertorManager
    {
        private double value = 0;
        private string temp = string.Empty;
        private Unit selectedUnit = Unit.None;
        private ISU selectedUnitISU = ISU.None;

        private PascalUnit pUnit;
        private BarUnit bUnit;
        private AtmUnit aUnit;

        public ConvertorManager()
        {
            pUnit = new PascalUnit();
            bUnit = new BarUnit();
            aUnit = new AtmUnit();
        }

        internal void Start()
        {
            do
            {
                PrintTitle();
                LoadValue();
                PrintUnits();
                StartConvert();
            } while (PrintContinue());
        }

        private bool PrintContinue()
        {
            bool cont = false;
            Console.WriteLine("Přejete si pokračovat? Y/N");
            do
            {
                temp = Console.ReadLine() ?? "";
                if (temp == "Y")
                {
                    cont = true;
                    break;
                }
                else if (temp == "N")
                {
                    cont = false;
                    break;
                }

            } while (true);

            return cont;
        }

        private void PrintTitle()
        {
            Console.WriteLine("Převod jednotek tlaku:");
            if (value != 0)
                Console.WriteLine("Hodnota: " + value + " " + selectedUnit.ToString());
        }

        private void LoadValue()
        {
            Console.WriteLine("Napište hodnotu na převedení (pomocí desetinné čárky):");
            do
            {
                temp = Console.ReadLine() ?? "";

            } while (!double.TryParse(temp, out value));

            temp = String.Empty;


        }
        private void PrintUnitsISU()
        {
            int i = 0;

            Console.WriteLine("Napište jednotku ISU zadané jednotky:");

            foreach (var hodnota in Enum.GetValues(typeof(ISU)))
            {                
                Console.WriteLine(i++ + ". " + hodnota);
            }


            do
            {
                temp = Console.ReadLine() ?? "";

            } while (!Enum.TryParse(temp, out selectedUnitISU));

            ChangeValueToBasicISU();

            Console.Clear();
            PrintTitle();

            temp = String.Empty;
        }

        private void ChangeValueToBasicISU()
        {
            value = pUnit.ConvertToNoneISU(value, selectedUnitISU);
            selectedUnitISU = ISU.None;
        }

        private void PrintUnits()
        {
            int i = 0;

            Console.WriteLine("Napište jednotku zadané hodnoty:");

            foreach (var hodnota in Enum.GetValues(typeof(Unit)))
            {
                if ((Unit)hodnota == Unit.None) continue;
                Console.WriteLine(++i + ". " + hodnota);
            }


            do
            {
                temp = Console.ReadLine() ?? "";

            } while (!Enum.TryParse(temp, out selectedUnit));

            temp = String.Empty;

            PrintUnitsISU();
        }


        private void StartConvert()
        {
            StringBuilder sb = new StringBuilder();

            switch (selectedUnit)
            {
                case Unit.Pa:
                    sb.AppendLine("Bar: " + pUnit.Convert(value, Unit.Bar, ISU.None));
                    sb.AppendLine("Atm: " + pUnit.Convert(value, Unit.Atm, ISU.None));
                    sb.AppendLine("Mili Pascal: " + pUnit.Convert(value, Unit.Pa, ISU.Mili));
                    break;                                    
                case Unit.Bar:
                    sb.AppendLine("Pascal: " + bUnit.Convert(value, Unit.Pa, ISU.None));
                    sb.AppendLine("Mili Pascal: " + bUnit.Convert(value, Unit.Pa, ISU.Mili));
                    sb.AppendLine("Atm: " + bUnit.Convert(value, Unit.Atm, ISU.None));
                    break;
                case Unit.Atm:
                    sb.AppendLine("Bar: " + aUnit.Convert(value, Unit.Bar, ISU.None));
                    sb.AppendLine("Pascal: " + aUnit.Convert(value, Unit.Pa, ISU.None));
                    sb.AppendLine("Mili Pascal: " + aUnit.Convert(value, Unit.Pa, ISU.Mili));
                    break;
                default:
                    break;

            }

            Console.WriteLine(sb);



        }
    }
}
