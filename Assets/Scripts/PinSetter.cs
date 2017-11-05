using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    private ActionMasterOld actionMaster = new ActionMasterOld();
    private Animator animator;
    public GameObject pinSet;
    private PinCounter pinCounter;



    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();

	}
	
	// Update is called once per frame
	void Update () {
        
	}
  

    public void RaisePins()
    {
        //podiže pinove za distanceToRaise
        Debug.Log("Raising Pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Raise();            
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

    public void PerformAction(ActionMasterOld.Action action)
    {
        Debug.Log(action);
        if (action == ActionMasterOld.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMasterOld.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Resetiraj();
        }
        else if (action == ActionMasterOld.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Resetiraj();
        }
        else if (action == ActionMasterOld.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle EndGame!");
        }

    }


}