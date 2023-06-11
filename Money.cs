using System;

namespace SelfEdu
{
    public class Money
    {
        public string? Rouble;
        public string? R_Currency;
        public string? Peny;
        public string? P_Currency;

        public Money(string money, string currency)
        {
            if (Convert.ToInt32(money) < 0)
                Console.WriteLine("Не может быть отрицательным!");
            else if(currency == "коп." && Convert.ToInt32(money) > 99)
            {
                if(Convert.ToInt32(money) % 100 == 0)
                {
                    Rouble = Convert.ToString(
                        Convert.ToInt32(money) / 100);
                    Peny = "0";
                }
                else if(Convert.ToInt32(money) % 100 != 0)
                {
                    Rouble = Convert.ToString(
                        Convert.ToInt32(money) / 100);
                    Peny = Convert.ToString(
                        Convert.ToInt32(money) % 100);
                }
                R_Currency = "р.";
                P_Currency = currency;
            }
            else if(currency == "р.")
            {
                Rouble = money;
                R_Currency = currency;
                Peny = "0";
                P_Currency = "коп.";
            }
            else if(currency == "коп.")
            {
                Peny = money;
                Rouble = "0";
                R_Currency = "р.";
                P_Currency = currency;
            }
            else
            {
                throw new ArgumentException("Не валидная сумма или валюта!");
            }
        }

        public Money(string rub,
            string r_curr,
            string peny,
            string p_curr):this(peny, p_curr)
        {
            if (r_curr == "коп." || p_curr == "р.")
                Console.WriteLine("Рубли и копейки поменялись местами");
            else if (Convert.ToInt32(rub) < 0)
                Console.WriteLine("Не может быть отрицательным!");
            else if(Convert.ToInt32(peny) > 99)
            {
                Rouble = Convert.ToString(
                    Convert.ToInt32(Rouble) + Convert.ToInt32(rub)); 
            }
            else
            {
                Rouble = rub;
                R_Currency = r_curr;
                Peny = peny;
                P_Currency = p_curr;
            }
            R_Currency = r_curr;
            P_Currency = p_curr;
        }
        public static Money Sum(Money a, Money b)
        {
            var rubPart = Convert.ToString(
                Convert.ToInt32(a.Rouble) + Convert.ToInt32(b.Rouble));
            var penyPart = Convert.ToString(
                Convert.ToInt32(a.Peny) + Convert.ToInt32(b.Peny));
            return new Money(rubPart, "р.", penyPart, "коп.");
        }

        public static Money Difference(Money a, Money b)
        {
            if(Convert.ToInt32(a.Peny) == 0 && Convert.ToInt32(b.Peny) == 0)
            {
                var rubParts = Convert.ToString(
                    Convert.ToInt32(a.Rouble) - Convert.ToInt32(b.Rouble));
                return new Money(rubParts, "р.", "0", "коп.");
            }
            else if(Convert.ToInt32(a.Peny) == 0 || Convert.ToInt32(b.Peny) == 0)
            {
                if(Convert.ToInt32(a.Peny) == 0)
                {
                    var rubDif = Convert.ToInt32(a.Rouble) - Convert.ToInt32(b.Rouble);
                    var dif = (rubDif * 100) - Convert.ToInt32(b.Peny);
                    var rubParts = Convert.ToString(dif / 100);
                    var penyParts = Convert.ToString(dif % 100);
                    return new Money(rubParts, "р.", penyParts, "коп.");
                }
                else if(Convert.ToInt32(b.Peny) == 0)
                {
                    var rubDif = Convert.ToInt32(b.Rouble) - Convert.ToInt32(a.Rouble);
                    var dif = (rubDif * 100) - Convert.ToInt32(a.Peny);
                    var rubParts = Convert.ToString(dif / 100);
                    var penyParts = Convert.ToString(dif % 100);
                    return new Money(rubParts, "р.", penyParts, "коп.");
                }
            }
            else if((Convert.ToInt32(a.Peny) < Convert.ToInt32(b.Peny))
                || (Convert.ToInt32(b.Peny) < Convert.ToInt32(a.Peny)))
            {
                if(Convert.ToInt32(a.Rouble) != 0 && Convert.ToInt32(b.Rouble) == 0)
                {
                    var rub = a.Rouble + a.Peny;
                    var res = Convert.ToInt32(rub);
                    var dif = res - Convert.ToInt32(b.Peny);
                    if(dif % 100 == 0)
                    {
                        var rubParts = Convert.ToString(
                            dif / 100);
                        return new Money(rubParts, "р.", "0", "коп.");
                    }
                    else
                    {
                        var rubParts = Convert.ToString(
                            dif / 100);
                        var penyParts = Convert.ToString(
                            dif % 100);
                        return new Money(rubParts, "р.", penyParts, "коп.");
                    }
                }
                else if (Convert.ToInt32(b.Rouble) != 0 && Convert.ToInt32(a.Rouble) == 0)
                {
                    var rub = b.Rouble + b.Peny;
                    var res = Convert.ToInt32(rub);
                    var dif = res - Convert.ToInt32(a.Peny);
                    if (dif % 100 == 0)
                    {
                        var rubParts = Convert.ToString(
                            dif / 100);
                        return new Money(rubParts, "р.", "0", "коп.");
                    }
                    else
                    {
                        var rubParts = Convert.ToString(
                            dif / 100);
                        var penyParts = Convert.ToString(
                            dif % 100);
                        return new Money(rubParts, "р.", penyParts, "коп.");
                    }
                }
            }
            var rubPart = Convert.ToString(
                    Convert.ToInt32(a.Rouble) - Convert.ToInt32(b.Rouble));
            var penyPart = Convert.ToString(
                Convert.ToInt32(a.Peny) - Convert.ToInt32(b.Peny));
            return new Money(rubPart, "р.", penyPart, "коп.");
        }
        public void PrintTransferedCount(double n)
        {
            double num = double.Parse(Rouble + "." + Peny);
            var res = Math.Round(num / 100 * n + num, 2);
            string[]? reverseConverter = Convert.ToString(res).Split(".");
            var rub = reverseConverter[0];
            var peny = reverseConverter[1];
            Console.WriteLine($"{rub} р. {peny}  коп.");

        }
        public void Print()
        {
            if (Convert.ToInt32(Rouble) != 0 || Convert.ToInt32(Peny) != 0)
                Console.WriteLine($"{Rouble} {R_Currency} {Peny} {P_Currency}");

        }
    }
}
