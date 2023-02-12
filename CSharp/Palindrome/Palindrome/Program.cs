using System;
using System.Text;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean fResult = PalindromeLocator.FIsPalindrome("Eva, can I see bees in a cave ? ", true, true);
        }
    }
    class PalindromeLocator
    {
        public static Boolean FIsPalindrome(String sText, Boolean fIgnoreNonAlpha, Boolean fIgnoreCase)
        {
            Boolean fRet = false;
            int i;
            if (fIgnoreCase)
            {
                sText = sText.ToUpperInvariant();
            }
            if (fIgnoreNonAlpha)
            {
                StringBuilder sb = new StringBuilder();
                for (i = 0; i < sText.Length; i++)
                {
                    Char ch = sText[i];
                    if (Char.IsLetter(ch))
                    {
                        sb.Append(ch);
                    }
                }
                sText = sb.ToString();
            }
            fRet = true;
            for (i = 0; i < sText.Length / 2; i++)
            {
                Char chL = sText[i];
                Char chR = sText[sText.Length - 1 - i];
                if (chR != chL)
                {
                    fRet = false;
                    break;
                }
            }
            return fRet;
        }
    }
}
