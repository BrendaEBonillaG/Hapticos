using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaInicial = 5;
    private int vidaActual; // Agrega esta línea para definir la variable de vida actual

    void Start()
    {
        vidaActual = vidaInicial;
    }

    public void ReducirVida(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            // El enemigo ha perdido toda su vida, así que destruye el objeto
            Destroy(gameObject);
           
            // Ahora, reduce 1 al valor de vida en el Controlador de Vida
            ControladorVida controladorVida = GameObject.Find("Controlador Vida").GetComponent<ControladorVida>();
            if (controladorVida != null)
            {
                controladorVida.vida--;
            }
        }

    }
}
