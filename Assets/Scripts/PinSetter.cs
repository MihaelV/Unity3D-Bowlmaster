using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;
    public GameObject pinSet;
    private Ball ball;
    public Text standingDisplay;
    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    //kada se je zadnje Text tj broj stojecih pinova promijenio
    private float lastChangeTime;
    private int lastSettledCount = 10;


    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();

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
	}

    public void SetBallOutOfPlay()
    {
        ballOutOfPlay = true;
    }

    public void RaisePins()
    {
        //podiže pinove za distanceToRaise
        Debug.Log("Raising Pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();
            pin.transform.rotation = Quaternion.Euler(270f,0,0); //uspravlja pin na točno 270°
        }
    }

    public void LowerPins()
    {
        Debug.Log("Lowering Pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing Pins");
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 20, 0);
    }

    void UpdateStandingCountAndsettle()
    {
        //update lastStandingCount
        //call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // how to long to wait to consider pins settled
        if ((Time.time - lastChangeTime)>settleTime) // if last change > 3s ago
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log(action);
        if(action == ActionMaster.Action.Tidy)
        {            
            animator.SetTrigger("tidyTrigger");
        }
        else if(action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if(action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle EndGame!");
        }

        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;

        //dok se pinovi smire resetiraj loptu
        ball.ResetirajLoptu();        
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


 
}
