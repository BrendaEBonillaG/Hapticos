using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVida : MonoBehaviour
{
    public int vida;
    public GameObject[] corazonesVida = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa la vida al valor inicial (3)
        vida = 3;

        // Busca y almacena los objetos de corazón en el arreglo
        corazonesVida[0] = GameObject.Find("corazon 1");
        corazonesVida[1] = GameObject.Find("corazon 2");
        corazonesVida[2] = GameObject.Find("corazon 3");
    }


    // Resta vida cuando un enemigo es destruido
    public void RestarVida()
    {
       // Debug.Log("vida menos");
        vida--;

        // Desactiva el objeto de corazón correspondiente
        if (vida >= 0 && vida < corazonesVida.Length)
        {
            corazonesVida[vida].SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Puedes agregar aquí cualquier otra lógica relacionada con la vida del jugador si es necesario.
    }
}
