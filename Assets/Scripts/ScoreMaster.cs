using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {


    //returns list of cumulative scores, like a normal score card
    public static List<int> ScoreCumulative (List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;


        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    //returns list of individual frame score, not Cumulative
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        //index i  points to 2nd bowl of frame
        for(int i = 1; i< rolls.Count; i += 2)  
        {
            if(frames.Count == 10)
            {
                break;
            }
            if (rolls[i-1]+rolls[i] < 10)// normal "open" frame, dok je zbroj dvije lopte u frejmu manji od 10
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }
            if(rolls.Count-i <= 1)  
            {
                break;
            }
            if(rolls[i-1] == 10) //strike
            {
                i--;  // oduzimamo 1 od i zato jer dok pogodimo svih 10 cunjica u prvom frejmu prvog bacanja idemo u drugi frejm i prvo i drugo bacanje drugog frejma se pribrajaju bodovima prvom frejma a nasa foreach petlja skace po dva
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if(rolls[i - 1] + rolls[i] == 10) // spare, pogodili smo u jednom frejmu(1 frame = 2 bacanja) sve cunjice dobivamo bonus od sljedeceg frejma prvo bacanje
            {
                frames.Add(10 + rolls[i + 1]);
            }
           

        }

        return frames;
    }
}
