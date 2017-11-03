using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{

    private Ball ball;

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Ball>();
    }

    public void MoveStart(float amount)
    {
        //ako smo lansirali loptu ne mozemo je vise micati lijevo ni desno
        if (ball.inPlay == false)
        {
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }
    }

    public void DragStart()
    {
        //vrijeme i pozicija od početne točke
        dragStart = Input.mousePosition;
        startTime = Time.time;

    }

    public void DragEnd()
    {
        //lansiraj
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;
        float launchSpeedX = (dragEnd.x-dragStart.x) / dragDuration;
        //input može biti samo x ili y mi koristimo y kako bi dobili z (translate)
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;


        //novi Vector3, u skripti Ball imamo funkciju koja lansira loptu i ulazni parametar je tipa Vector 3
        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.LaunchBall(launchVelocity);

    }
}
