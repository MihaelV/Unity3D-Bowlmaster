﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingTreshold = 3f;
    public float distanceToRaise = 40f;


    private Rigidbody rigid;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public bool IsStanding()
    {
        Vector3 rotationinEuler = transform.rotation.eulerAngles;
        
        //rotacija pina u x i z kordinati
        //Mathf.Abs apsolutna vrijednos 3 = -3
        float tiltX = Mathf.Abs(270 - rotationinEuler.x); // 270 zato jer smo ih zavrtili -90
        float tiltZ = Mathf.Abs(rotationinEuler.z);

        if(tiltX<standingTreshold && tiltZ < standingTreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void Raise()
    {
        if (IsStanding())
        {
            rigid.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0); //uspravlja pin na točno 270°

        }
    }

    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
            rigid.useGravity = true;
        }      
    }
}
