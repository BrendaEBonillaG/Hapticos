using UnityEngine;
using UnityEngine.SceneManagement; // La corrección está aquí, debes importar 'UnityEngine.SceneManagement' en lugar de 'UnityEngine.SceneManagment'.



public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
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

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    
}
