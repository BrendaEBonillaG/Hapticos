using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class powerup : MonoBehaviour
{
    [SerializeField]
    public Image Powerup;
    [SerializeField]
    //private TMP_Text textPowerAnt;

    public bool isPowerUp = false;
    private bool isDirectionUp = true;
    public float antPower = 0.0f;
    private float powerSpeed = 10.0f;




    ////variable para saber que tan llena esta la barra actualmente
    //public float powerupActual;

    ////maximo de llenado (100)
    //public float powerupMaxima;


    // Update is called once per frame
    void Update()
    {
        if (isPowerUp)
        {
            PowerActive();
        }
    }

    void PowerActive()
    {
        if (isDirectionUp)
        {
            antPower += Time.deltaTime * powerSpeed;
            if (antPower > 100)
            {
                isDirectionUp = false;
                antPower = 100.0f;
            }
        }
        else
        {
            //antPower -= Time.deltaTime * powerSpeed;
            //if(antPower < 0)
            //{
            //    isDirectionUp = true;
            //    antPower = 0.0f;
            //}
        }
        Powerup.fillAmount = antPower / 100.0f;
    }
    public void StartPowerUp()
    {
        if (antPower == 100)
        {
            isPowerUp = true;
            antPower = 0.0f;
            isDirectionUp = true;
        }

        //textPowerAnt.text = "";
    }

    public void EndPowerUp()
    {
        isPowerUp = false;

    }

}
