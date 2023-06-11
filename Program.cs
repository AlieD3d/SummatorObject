// 1. Create class Money
// 2. init fields Rouble,Rouble_Currency, Peny, Peny_Currency
// 3. init constructor {a,rub or kop} or {a,b,c,d}
// 4. Verify if peny > 99; curr_r == 'kop.'or  curr_r == 'p.' => PrintExcept; value < 0 => PrintExcept
// 5. Create method static method Sum(inst a, inst b) -> new obj ClassInsts
// 6. -||- (fixed name method to Difference)
// 7. Create method PrintTransferedCount(double x): formula((sum / 100 * x) + sum)
// 8. Create method Print() -> print sum to console

// cases:
// 1. input("-10", "p.") -> Console.WriteLine();
// 2. input("10", "p.", "251", "kop.") -> 12 p. 51 kop.;
// 3. Diff obj1 input("2"," p", "0") - Diff obj2("3", "p.", "90", "kop.") -> -1 p. 10 kop.;
/*
 void HelperValidator(inst a , inst b)
{
    (if a.Peny == 0 && b.Peny == 0)
    {
        var tmp = Convt.Toint32(a.Rouble) - Covn.Int32(b.Rouble);
        Rouble = Convt.ToStr(tmp);
    }
    var tmp = Convrt.ToInt32(a.Roub) * 100 - Convr.Toint32(b.Peny);
    Rouble = Convt.ToString(Convt.ToInt32(tmp / 100));
    Peny = Convt.ToStrint(Convtr.ToInt32(tmp) % 100));
}
 */


using System;


class Program
{
    public static void Main()
    {
        var testObjA = new SelfEdu.Money("10", "р.", "15", "коп.");
        var testObjB = new SelfEdu.Money("0", "руб", "75", "коп.");
        var sum = SelfEdu.Money.Sum(testObjA, testObjB);
        sum.Print();
        var diff = SelfEdu.Money.Difference(testObjA, testObjB);
        diff.Print();
        sum.PrintTransferedCount(5);
        diff.PrintTransferedCount(0.05);


    }
}