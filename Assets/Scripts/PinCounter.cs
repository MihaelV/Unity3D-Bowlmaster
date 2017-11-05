using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;
    private GameManager gameManager;

    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    //kada se je zadnje Text tj broj stojecih pinova promijenio
    private float lastChangeTime;
    private int lastSettledCount = 10;


    // Use this for initialization
    void Start () {        
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString(); //update na UI text koji sadrzi broj stojecih pinova


        //if ball entered box
        if (ballOutOfPlay)
        {
            UpdateStandingCountAndsettle();
            standingDisplay.color = Color.red;
        }
        else
        {
            standingDisplay.color = Color.green;
        }
    }


    public void Resetiraj()
    {
        lastSettledCount = 10;
    }

    void UpdateStandingCountAndsettle()
    {
        //update lastStandingCount
        //call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // how to long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) // if last change > 3s ago
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {

        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        //ActionMaster.Action action = actionMaster.Bowl(pinFall);
        gameManager.Bowl(pinFall);
        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;

        //dok se pinovi smire resetiraj loptu
        //ball.ResetirajLoptu();
    }


    int CountStanding()
    {
        int standing = 0;
        //Prolazimo kroz sve pinove i provjeravamo dali stoje 
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }
}
