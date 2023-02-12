using System;

class Program
{
    static void Main(string[] args)
    {
        BioRhythmCalculator brc = new BioRhythmCalculator(new DateTime(1961, 8, 12));
        DateTime dtNow = DateTime.Today;
        for (int i = 0; i<30; i++)
        {
            DateTime dtCur = dtNow.AddDays(i);
            PrintQuotients(brc, dtCur);
        }

        Console.WriteLine("Please ENTER to end the program ...");
        Console.ReadLine();
    }
    static void PrintQuotients(BioRhythmCalculator brc, DateTime dtCur)
    {
        double qQIntellectual = brc.getQuotientIntellectual(dtCur);
        double qQPhysical = brc.getQuotientPhysical(dtCur);
        double qQEmotional = brc.getQuotientEmotional(dtCur);
        Console.WriteLine(dtCur.ToString("dd/MMM/yyyy") + " : I = " + qQIntellectual + " P = " + qQPhysical + " E =" + qQEmotional);
    }
}
class BioRhythmCalculator
{
    DateTime _dtBirthDate;
    private static int __jCycleLengthIntellectual = 33;
    private static int __jCycleLengthPhysical = 23;
    private static int __jCycleLengthEmotional = 28;
        private static int __jCycleLengthEmotional = 28;
    public BioRhythmCalculator(DateTime dtBirthDate)
    {
        _dtBirthDate = dtBirthDate;
    }
    public double getQuotientIntellectual(DateTime dtTarget)
    {
        return getQuotient(dtTarget, __jCycleLengthIntellectual);
    }
    public double getQuotientPhysical(DateTime dtTarget)
    {
        return getQuotient(dtTarget, __jCycleLengthPhysical);
    }
    public double getQuotientEmotional(DateTime dtTarget)
    {
        return getQuotient(dtTarget, __jCycleLengthEmotional);
    }
    private double getQuotient(DateTime dtTarget, int nCycleLength)
    {
        TimeSpan ts = dtTarget - this._dtBirthDate;
        int nDaysDifference = ts.Days;
        if (nDaysDifference < 0)
        {
            nDaysDifference = -nDaysDifference;
        }
        int jDiffMod = nDaysDifference % nCycleLength;
        double qAngle = 2.0 * jDiffMod * Math.PI / nCycleLength;
        double qRet = Math.Sin(qAngle);
        return qRet;
    }
}
