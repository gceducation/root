using System;
using System.Collections.Generic;

public class Prog1
{
    public static void Main(String[] args)
    {
        //String[] arrstrTeams =
        //{

        //    "AUS",
        //    "ENG",
        //    "IND",
        //    "NZL",
        //    "PAK",
        //    "SAF",
        //    //"SLK",
        //    //"WIN",
        //    //"ZIM",
        //    //"BAN",
        //    //"IRE",
        //    //"AFG"
        //};
        String[] arrstrTeams = new string[30];
        Random rnd = new Random();
        for (int j = 0; j < arrstrTeams.Length; j++)
        {
            arrstrTeams[j] = rnd.NextDouble().ToString();
        }
            String[] arrsSched = doScheduleRoundRobin(arrstrTeams);
        for (int j = 0; j < arrsSched.Length; j++)
        {
            Console.WriteLine(arrsSched[j]);
        }
        Console.WriteLine("Done");
    }

    private static String[] doScheduleRoundRobin(String[] arrstrTeams)
    {
        String[] arrsSched = new String[arrstrTeams.Length * (arrstrTeams.Length - 1) / 2];
        int jCurSched = 0;
        String[] asTeams = null;
        if (arrstrTeams.Length % 2 != 0)
        {
            asTeams = new string[arrstrTeams.Length + 1];

            for (int j = 0; j < arrstrTeams.Length; j++)
            {
                asTeams[j] = arrstrTeams[j];
            }
            asTeams[asTeams.Length - 1] = "---";
        }
        else
        {
            asTeams = arrstrTeams;
        }
        int jRound = 0;
        Boolean fDone = false;
        int nTeams = asTeams.Length;
        while (!fDone)
        {
            int jTeam1 = nTeams / 2 - 1;
            arrsSched[jCurSched]= "Day " + jRound + " : " + asTeams[nTeams - 1] + " x " + asTeams[jTeam1];
            jCurSched++;
            int jTeam0 = jTeam1;
            while (jTeam1 > 0)
            {
                jTeam1--;
                jTeam0++;
                arrsSched[jCurSched] = "Day " + jRound + " : " + asTeams[jTeam1] + " x " + asTeams[jTeam0];
                jCurSched++;
            }
            jRound++;
            if (jRound + 1 == nTeams)
            {
                fDone = true;
            }
            else
            {
                shiftArray(asTeams);
            }
        }
        return arrsSched;
    }

    private static void shiftArray(string[] asTeams)
    {
        // Anchor the last element shift others by 1 position
        int nLengthRot = (asTeams.Length - 1);
        String sTemp = asTeams[0];
        for (int j = 0; j < nLengthRot; j++)
        {
            int jTeamNext = (j + 1) % nLengthRot;            
            asTeams[j] = asTeams[jTeamNext];           
        }
        asTeams[nLengthRot - 1] = sTemp;

    }
}
