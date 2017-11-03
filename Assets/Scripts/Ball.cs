using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skripta zahtijeva GameObject da ima RigidBody componentu
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

    private Rigidbody rigidb;
    private AudioSource rollingBallSound;

    
    public Vector3 launchVelocity;

    public bool inPlay = false;

    public Vector3 ballStartPosition; 

	// Use this for initialization
	void Start ()
    {
        rigidb = GetComponent<Rigidbody>();        
        rigidb.useGravity = false; // isključujemo gravitaciju da lopta ostane u zraku        
        //LaunchBall(launchVelocity);
        ballStartPosition = transform.position;

    }

    public void LaunchBall(Vector3 velocity)
    {        
        inPlay = true;
        rigidb.useGravity = true;
        rigidb.velocity = velocity;

        rollingBallSound = GetComponent<AudioSource>();
        rollingBallSound.Play();
    }

    public void ResetirajLoptu()
    {
        inPlay = false;
        transform.position = ballStartPosition; // resetiramo poziciju lopte na početnu poziciju koju smo snimili u varijablu ballStartPosition
        rigidb.useGravity = false; // spriječavamo loptu da padne dole kad je resetirana
        rigidb.velocity = Vector3.zero;  // sprečavamo loptu da se opet lansira
        rigidb.angularVelocity = Vector3.zero; // sprečavamo loptu da se okreče na mjestu
     


        Debug.Log("Reset ball");
    }

}
