using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>(); // lista za spremanje stanja
    private ScoreDisplay scoreDisplay;

    private PinSetter pinSetter;
    private Ball ball;


	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Bowl (int pinFall)
    {
        try
        {
            rolls.Add(pinFall);
            ball.ResetirajLoptu();
            pinSetter.PerformAction(ActionMasterOld.NextAction(rolls));
        }
        catch
        {
            Debug.LogWarning("Something went wrong in Bowl()");
        }



        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch
        {
            Debug.LogWarning("FillRollCard failed");
        }
    }
}
