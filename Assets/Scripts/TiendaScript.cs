using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TiendaScript : MonoBehaviour
{
    public Text precioMejorasText; 
    public Text precioGatosNaranjasText; 
    public Text precioGatosNegroText; 
    public Text precioGatosPersaText; 

    public int precioGatoNaranja;
    public int precioGatoNegro;
    public int precioGatoPersa;
    public int precioMejoras;

    public GameObject objetoGatoNaranja;

    public static int nivelHabitacionn =1;

    public Camera camara;

    public float rango = 1f; 

    void Start()
    {
        //precioMejoras = 0;
        precioGatoNaranja = 50;
        precioGatoNegro = 100;
        precioGatoPersa = 250;
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

        precioGatosNaranjasText.text = "Precio: " + $"{precioGatoNaranja}";
        precioMejorasText.text = "Precio: " + $"{precioMejoras}";
        precioGatosNegroText.text = "Precio: " + $"{precioGatoNegro}";
        precioGatosPersaText.text = "Precio: " + $"{precioGatoPersa}";
        
    }

    public void Mejorar()
    {
        if(AgregarGatos.nivelHabitacion <= 4)
        {
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= 50)
            {
                nivelHabitacionn++;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoNaranja;
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
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= precioGatoNaranja && AgregarGatos.gatosEnHabitacion < 4)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                precioGatoNaranja += 50;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoNaranja;
            }
            if(AgregarGatos.nivelHabitacion == 2 && ScriptCoins.produccionMonedasHabitacion >= 50 && AgregarGatos.gatosEnHabitacion < 8)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                precioGatoNaranja += 50;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }
            if(AgregarGatos.nivelHabitacion == 3 && ScriptCoins.produccionMonedasHabitacion >= 50 && AgregarGatos.gatosEnHabitacion < 15)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                precioGatoNaranja += 50;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }
            if(AgregarGatos.nivelHabitacion == 4 && ScriptCoins.produccionMonedasHabitacion >= 50 && AgregarGatos.gatosEnHabitacion < 20)
            {
                AgregarGatos.gatosNaranjasEnHabitacion++;
                precioGatoNaranja += 50;
                ScriptCoins.produccionMonedasHabitacion -= 50;
            }
            
        }
    }

    public void ComprarGatosNegros()
    {
        if(AgregarGatos.nivelHabitacion <= 4)
        {
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= precioGatoNegro && AgregarGatos.gatosEnHabitacion < 4)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                precioGatoNegro += 100;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoNegro;
            }
            if(AgregarGatos.nivelHabitacion == 2 && ScriptCoins.produccionMonedasHabitacion >= precioGatoNegro && AgregarGatos.gatosEnHabitacion < 8)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                precioGatoNegro += 100;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoNegro;
            }
            if(AgregarGatos.nivelHabitacion == 3 && ScriptCoins.produccionMonedasHabitacion >= precioGatoNegro && AgregarGatos.gatosEnHabitacion < 15)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                precioGatoNegro += 100;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoNegro;
            }
            if(AgregarGatos.nivelHabitacion == 4 && ScriptCoins.produccionMonedasHabitacion >= precioGatoNegro && AgregarGatos.gatosEnHabitacion < 20)
            {
                AgregarGatos.gatosNegrosEnHabitacion++;
                precioGatoNegro += 100;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoNegro;
            }
            
        }
    }public void ComprarGatosPersa()
    {
        if(AgregarGatos.nivelHabitacion <= 4)
        {
            if(AgregarGatos.nivelHabitacion == 1 && ScriptCoins.produccionMonedasHabitacion >= precioGatoPersa && AgregarGatos.gatosEnHabitacion < 4)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                precioGatoPersa += 300;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoPersa;
            }
            if(AgregarGatos.nivelHabitacion == 2 && ScriptCoins.produccionMonedasHabitacion >= precioGatoPersa && AgregarGatos.gatosEnHabitacion < 8)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                precioGatoPersa += 300;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoPersa;
            }
            if(AgregarGatos.nivelHabitacion == 3 && ScriptCoins.produccionMonedasHabitacion >= precioGatoPersa && AgregarGatos.gatosEnHabitacion < 15)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                precioGatoPersa += 300;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoPersa;
            }
            if(AgregarGatos.nivelHabitacion == 4 && ScriptCoins.produccionMonedasHabitacion >= precioGatoPersa && AgregarGatos.gatosEnHabitacion < 20)
            {
                AgregarGatos.gatosPersaEnHabitacion++;
                precioGatoPersa += 300;
                ScriptCoins.produccionMonedasHabitacion -= precioGatoPersa;
            }
            
        }
    }
}
