using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaBisonte : MonoBehaviour
{
    public int vidaInicial = 50; // Vida inicial del bisonte
    private int vidaActual; // Vida actual del bisonte

    void Start()
    {
        vidaActual = vidaInicial;
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {

            // El bisonte ha perdido toda su vida, así que destruye el objeto
            Destroy(gameObject);
            int siguienteEscena = SceneManager.GetActiveScene().buildIndex + 1;

            // Comprobar si la siguiente escena existe antes de cargarla
            if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(siguienteEscena);
            }
            else
            {
                Debug.LogWarning("No hay siguiente escena disponible.");
            }
        }
    }
}
