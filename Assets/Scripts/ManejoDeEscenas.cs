using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoDeEscenas : MonoBehaviour
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
        SceneManager.LoadScene("Inicio");
    }

    public void Hotel()
    {
        SceneManager.LoadScene("Hotel");
    }

    public void Tienda()
    {
        SceneManager.LoadScene("Tienda");
    }

    public void Habitacion1()
    {
        SceneManager.LoadScene("1");
    }

    public void Habitacion2()
    {
        SceneManager.LoadScene("2");
    }
    
    public void Habitacion3()
    {
        SceneManager.LoadScene("3");
    }

    public void Habitacion4()
    {
        SceneManager.LoadScene("4");
    }
}
