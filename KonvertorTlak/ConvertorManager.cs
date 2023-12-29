using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonvertorTlak
{
    internal class ConvertorManager
    {
        private double value = 0;
        private string temp = string.Empty;
        private Unit selectedUnit = Unit.None;

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
            Console.WriteLine("Napište hodnotu na převedení:");
            do
            {
                temp = Console.ReadLine() ?? "";

            } while (!double.TryParse(temp, out value));

            temp = String.Empty;
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

            Console.Clear();
            PrintTitle();

            temp = String.Empty;
        }


        private void StartConvert()
        {
            StringBuilder sb = new StringBuilder();

            switch (selectedUnit)
            {
                case Unit.Pa:
                    sb.AppendLine("Bar: " + pUnit.Convert(value, Unit.Bar));
                    sb.AppendLine("Atm: " + pUnit.Convert(value, Unit.Atm));
                    break;
                case Unit.Bar:
                    sb.AppendLine("Pascal: " + bUnit.Convert(value, Unit.Pa));
                    sb.AppendLine("Atm: " + bUnit.Convert(value, Unit.Atm));
                    break;
                case Unit.Atm:
                    sb.AppendLine("Bar: " + aUnit.Convert(value, Unit.Bar));
                    sb.AppendLine("Pascal: " + aUnit.Convert(value, Unit.Pa));
                    break;
                default:
                    break;

            }

            Console.WriteLine(sb);



        }
    }
}
