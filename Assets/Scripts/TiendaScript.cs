using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaScript : MonoBehaviour
{
    public Text precioMejorasText; 
    public int precioMejoras;

    public static int nivelHabitacionn =1;

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
}
