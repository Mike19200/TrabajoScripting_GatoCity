using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Juego");
    }

    public void EscenaColeccionGatos()
    {
        SceneManager.LoadScene("Cats");
    }

    public void EscenaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
