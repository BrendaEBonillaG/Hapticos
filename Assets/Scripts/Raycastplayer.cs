using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Raycastplayer : MonoBehaviour
{
    public static Raycastplayer instance;

    private bool isXPressed = false;
    private float raycastCooldown = 0.5f; // Medio segundo de cooldown
    private float lastRaycastTime = 0f;
    //public Collision colision;
    public ControladorVida controladorVida;
    ControladorVida funcionrestar;
    public int aux = 0;
    public Bate bate;

    private void Start()
    {
        funcionrestar = GetComponent<ControladorVida>();
        instance = this;
    }
    void Update()
    {
        if (Time.time - lastRaycastTime >= raycastCooldown)
        {
            lastRaycastTime = Time.time;
            isXPressed = true;
        }
        else
        {
            isXPressed = false;
            
        }

        if (isXPressed)
        {
            // Realiza el raycast y reduce la vida del objeto impactado
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * 30f, Color.red);
                Debug.Log("Distancia: " + hit.distance);
                Debug.Log("Punto de impacto: " + hit.point);

                if (hit.transform.CompareTag("Bisonte") && bate.qy > 0.20)
                {
                    Debug.Log("Golpe Bisonte");
                    VidaBisonte vidaBisonte = hit.transform.GetComponent<VidaBisonte>();
                    if (vidaBisonte != null)
                    {
                        vidaBisonte.RecibirDanio(5);
                    }
                }
                else if (/*hit.transform.CompareTag("Malo")  && bate.qy > 0.20*/  Input.GetKeyDown(KeyCode.Space))
                {
                    aux = 1;
                    Debug.Log("Golpe morro");
                    VidaEnemigo vidaEnemigo = hit.transform.GetComponent<VidaEnemigo>();
                    if (vidaEnemigo != null)
                    {
                        vidaEnemigo.ReducirVida(5);
                        Destroy(hit.transform.gameObject);
                        funcionrestar.RestarVida();
                        // Llamamos a la función para actualizar los corazones en el Controlador de Vida
                        //ActualizarCorazonesVida();
                        // void OnCollisionEnter(Collision collision)
                        //{
                        //    if (collision.gameObject.CompareTag("Malo"))
                        //    {
                        //        //Debug.Log("vida--");
                        //        controladorVida.vida--;
                        //        //Debug.Log(controladorVida.vida);
                        //        //this.vida

                        //        switch (controladorVida.vida)
                        //        {
                        //            case 3:
                        //                //Debug.Log("Vida-3");

                        //                controladorVida.corazonesVida[0].SetActive(true);
                        //                controladorVida.corazonesVida[1].SetActive(true);
                        //                controladorVida.corazonesVida[2].SetActive(true);
                        //                break;

                        //            case 2:
                        //                //Debug.Log("Vida-2");
                        //                controladorVida.corazonesVida[0].SetActive(true);
                        //                controladorVida.corazonesVida[1].SetActive(true);
                        //                controladorVida.corazonesVida[2].SetActive(false);
                        //                break;

                        //            case 1:
                        //                //Debug.Log("Vida-1");
                        //                controladorVida.corazonesVida[0].SetActive(true);
                        //                controladorVida.corazonesVida[1].SetActive(false);
                        //                controladorVida.corazonesVida[2].SetActive(false);
                        //                break;

                        //            case 0:
                        //                //Debug.Log("Vida-0");
                        //                controladorVida.corazonesVida[0].SetActive(false);
                        //                controladorVida.corazonesVida[1].SetActive(false);
                        //                controladorVida.corazonesVida[2].SetActive(false);
                        //                //Aqui poner la funcion para game over
                        //                break;

                        //            default:
                        //                break;
                        //        }


                        //    }
                        //}




                    }
                }
            }
        }
    }

    // Función para actualizar los corazones en el Controlador de Vida
    private void ActualizarCorazonesVida()
    {
        if (controladorVida != null)
        {
            controladorVida.vida--;

            if (controladorVida.vida >= 0 && controladorVida.vida < controladorVida.corazonesVida.Length)
            {
                controladorVida.corazonesVida[controladorVida.vida].SetActive(false);
            }
        }
    }
}
