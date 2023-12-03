using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConPlayer : MonoBehaviour
{
    private Transform transPlayer;
    [SerializeField] private float velocidad;
    private GameObject enemigo;
    private int vida;
    private ControladorVida controladorVida;

    // Start is called before the first frame update
    void Start()
    {
        transPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemigo = GameObject.FindGameObjectWithTag("Malo");
        controladorVida = GameObject.Find("Controlador Vida").GetComponent<ControladorVida>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    transPlayer.Translate(Vector3.right * velocidad * Time.deltaTime);
        //}
        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    transPlayer.Translate(Vector3.left * velocidad * Time.deltaTime);
        //}
        //if (Input.GetAxis("Vertical") > 0)
        //{
        //    transPlayer.Translate(Vector3.forward * velocidad * Time.deltaTime);
        //}
        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    transPlayer.Translate(Vector3.back * velocidad * Time.deltaTime);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Malo"))
        {
            Debug.Log("vida--");
            controladorVida.vida--;
            //Debug.Log(controladorVida.vida);
            //this.vida

            switch (controladorVida.vida)
            {
                case 3:
                    //Debug.Log("Vida-3");

                    controladorVida.corazonesVida[0].SetActive(true);
                    controladorVida.corazonesVida[1].SetActive(true);
                    controladorVida.corazonesVida[2].SetActive(true);
                    break;

                case 2:
                    //Debug.Log("Vida-2");
                    controladorVida.corazonesVida[0].SetActive(true);
                    controladorVida.corazonesVida[1].SetActive(true);
                    controladorVida.corazonesVida[2].SetActive(false);
                    break;

                case 1:
                    //Debug.Log("Vida-1");
                    controladorVida.corazonesVida[0].SetActive(true);
                    controladorVida.corazonesVida[1].SetActive(false);
                    controladorVida.corazonesVida[2].SetActive(false);
                    break;

                case 0:
                    //Debug.Log("Vida-0");
                    controladorVida.corazonesVida[0].SetActive(false);
                    controladorVida.corazonesVida[1].SetActive(false);
                    controladorVida.corazonesVida[2].SetActive(false);
                    //Aqui poner la funcion para game over
                    break;

                default:
                    break;
            }


        }
    }
}
