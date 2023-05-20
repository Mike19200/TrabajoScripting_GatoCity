using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TiendaScript : MonoBehaviour
{
    public Text precioMejorasText; 
    public int precioMejoras;

    public GameObject objetoGatoNaranja;

    public static int nivelHabitacionn =1;

    public Camera camara;

    public float rango = 1f; 

    void Start()
    {
        //precioMejoras = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(nivelHabitacionn == 1)
        {
            precioMejoras = 50;
        }
        if(nivelHabitacionn == 2)
        {
            precioMejoras = 150;
        }
        if(nivelHabitacionn == 3)
        {
            precioMejoras = 350;
        }
        if(nivelHabitacionn == 4)
        {
            precioMejoras = 700;
        }
        precioMejorasText.text = "Precio: " + $"{precioMejoras}";
    }

    public void Mejorar()
    {
        if(AgregarGatos.nivelHabitacion <= 4)
        {
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= 50)
            {
                nivelHabitacionn++;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }

            if(AgregarGatos.nivelHabitacion == 2 && ScriptCoins.produccionMonedasHabitacion >= 150)
            {
                nivelHabitacionn++;
                ScriptCoins.produccionMonedasHabitacion -= 150;
            }

            if(AgregarGatos.nivelHabitacion == 3 && ScriptCoins.produccionMonedasHabitacion >= 350)
            {
                nivelHabitacionn++;
                ScriptCoins.produccionMonedasHabitacion -= 350;
            }

            if(AgregarGatos.nivelHabitacion == 4 && ScriptCoins.produccionMonedasHabitacion >= 700)
            {
                nivelHabitacionn++;
                ScriptCoins.produccionMonedasHabitacion -= 700;
            }
            
        }
    }

    public void ComprarGatosNaranjas()
    {
        if(AgregarGatos.nivelHabitacion <= 4)
        {
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= 50 && AgregarGatos.gatosEnHabitacion < 4)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }
            if(AgregarGatos.nivelHabitacion == 2 && ScriptCoins.produccionMonedasHabitacion >= 50 && AgregarGatos.gatosEnHabitacion < 8)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }
            if(AgregarGatos.nivelHabitacion == 3 && ScriptCoins.produccionMonedasHabitacion >= 50 && AgregarGatos.gatosEnHabitacion < 15)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }
            if(AgregarGatos.nivelHabitacion == 4 && ScriptCoins.produccionMonedasHabitacion >= 50 && AgregarGatos.gatosEnHabitacion < 20)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }
            
        }
    }

    public void ComprarGatosNegros()
    {
        if(AgregarGatos.nivelHabitacion <= 4)
        {
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= 100 && AgregarGatos.gatosEnHabitacion < 4)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 100;
            }
            if(AgregarGatos.nivelHabitacion == 2 && ScriptCoins.produccionMonedasHabitacion >= 100 && AgregarGatos.gatosEnHabitacion < 8)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 100;
            }
            if(AgregarGatos.nivelHabitacion == 3 && ScriptCoins.produccionMonedasHabitacion >= 100 && AgregarGatos.gatosEnHabitacion < 15)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 100;
            }
            if(AgregarGatos.nivelHabitacion == 4 && ScriptCoins.produccionMonedasHabitacion >= 100 && AgregarGatos.gatosEnHabitacion < 20)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 100;
            }
            
        }
    }public void ComprarGatosPersa()
    {
        if(AgregarGatos.nivelHabitacion <= 4)
        {
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= 250 && AgregarGatos.gatosEnHabitacion < 4)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 250;
            }
            if(AgregarGatos.nivelHabitacion == 2 && ScriptCoins.produccionMonedasHabitacion >= 250 && AgregarGatos.gatosEnHabitacion < 8)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 250;
            }
            if(AgregarGatos.nivelHabitacion == 3 && ScriptCoins.produccionMonedasHabitacion >= 250 && AgregarGatos.gatosEnHabitacion < 15)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 250;
            }
            if(AgregarGatos.nivelHabitacion == 4 && ScriptCoins.produccionMonedasHabitacion >= 250 && AgregarGatos.gatosEnHabitacion < 20)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                ScriptCoins.produccionMonedasHabitacion -= 250;
            }
            
        }
    }
}
