using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidMovement : MonoBehaviour
{
    public powerup controladorPowerUp;

    public Bate bate;

    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float originalSpeed = 6f;
    [SerializeField] float reducedSpeed = 3f;

    private bool isZEnabled = false;
    private bool PowerUpOn = false;


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        if (/*isZEnabled &&*/ bate.boton==0)
        {
            if (controladorPowerUp.antPower == 100)
            {
                controladorPowerUp.StartPowerUp();
                MoveWithSpeed(reducedSpeed);
                PowerUpOn = true;
            }
            else if (controladorPowerUp.antPower < 30)
            {
                MoveWithSpeed(reducedSpeed);
            }
            else
            {
                MoveWithSpeed(originalSpeed);
                //PowerUpOn = false;
            }
        }
        if (PowerUpOn)
        {
            MoveWithSpeed(reducedSpeed);
            if (controladorPowerUp.antPower > 30)
            {
                PowerUpOn = false;
            }
        }
        else
        {
            MoveWithSpeed(originalSpeed);
        }
    }

    private void MoveWithSpeed(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }

    public void EnableZ(bool enable)
    {
        isZEnabled = enable;
    }
}

