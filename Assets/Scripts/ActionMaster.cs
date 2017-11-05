using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action { Tidy, Reset, EndTurn, EndGame };
    private int[] bowls = new int[21];
    private int bowl = 1;

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10) { throw new UnityException("Invalid input"); }

        bowls[bowl - 1] = pins;

        if (bowl == 21)
        {
            return Action.EndGame;
        }

        if (bowl >= 19 && pins == 10)
        {
            bowl++;
            return Action.Reset;
        }
        else if (bowl == 20)
        {
            bowl++;
            if (bowls[19 - 1] == 10 && bowls[20 - 1] == 0)
            {
                return Action.Tidy;
            }
            else if (bowls[19 - 1] + bowls[20 - 1] == 10)
            {
                return Action.Reset;
            }
            else if (bowls[19 - 1] == 10 && bowls[20 - 1] < 10)
            {
                return Action.Tidy;
            }
            else if (Bowl21Awarded())
            {
                return Action.Tidy;
            }
            else
            {
                return Action.EndGame;
            }
        }


        if (bowl % 2 != 0)
        {
            if(pins == 10)
            {
                bowl += 2;
                return Action.EndTurn;
            }
            else
            {
                bowl ++;
                return Action.Tidy;
            }
        }
        else if (bowl % 2 == 0)
        {
            bowl++;
            return Action.EndTurn;
        }


        //moj način također prolazi testove do T11
        //if (pins == 10)
        //{            
        //    if(bowl %2 == 0)
        //    {
        //        bowl++;
        //        return Action.EndTurn;
        //    }else if(bowl %2 != 0)
        //    {
        //        bowl += 2;
        //        return Action.EndTurn;
        //    }
            
        //}
        ////if first bowl of frame 
        ////return Action.Tidy;
        //if (bowl % 2 != 0) // mid frame
        //{
        //    bowl++;
        //    return Action.Tidy;
        //}
        //else if (bowl % 2 == 0) // end of frame
        //{
        //    bowl++;
        //    return Action.EndTurn;
        //}

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded()
    {
        return ((bowls[19 - 1] + bowls[20 - 1] % 10) == 0);
    }
}
    