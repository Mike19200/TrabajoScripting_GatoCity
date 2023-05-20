using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgregarGatos : MonoBehaviour
{
    public static int gatosEnHabitacion = 0; 

    public static int gatosNaranjasEnHabitacion=0;
    public static int gatosNegrosEnHabitacion=0;
    public static int gatosPersaEnHabitacion=0;
    public float felicidadGatos = 0;

    public static int nivelHabitacion = 1;
    public Text textoGatosEnHabitacion; 
    public Text felicidadGatosTexto; 
    public GameObject objetoGatoNaranja; 
    public GameObject objetoGatoNegro; 
    public GameObject objetoGatoPersa; 
    public Camera camara;

    public float rango = 1f; 
    public float velocidadAumentoFelicidad = 0.0000005f;

    public void Start() 
    {
        nivelHabitacion = TiendaScript.nivelHabitacionn;
        gatosEnHabitacion = gatosNaranjasEnHabitacion + gatosNegrosEnHabitacion + gatosPersaEnHabitacion ;
        for (int i = 0; i < gatosNaranjasEnHabitacion; i++)
        {
           Vector3 posicionAleatoria = transform.position + Random.insideUnitSphere * rango;
           Vector3 vistaPos = camara.WorldToViewportPoint(posicionAleatoria);
        
           if(vistaPos.x >= 0 && vistaPos.x <= 1 && vistaPos.y >= 0 && vistaPos.y <= 1 && vistaPos.z > 0) 
           {
            Instantiate(objetoGatoNaranja, posicionAleatoria, Quaternion.identity);
           }
        }
        for (int i = 0; i < gatosNegrosEnHabitacion; i++)
        {
           Vector3 posicionAleatoria = transform.position + Random.insideUnitSphere * rango;
           Vector3 vistaPos = camara.WorldToViewportPoint(posicionAleatoria);
        
           if(vistaPos.x >= 0 && vistaPos.x <= 1 && vistaPos.y >= 0 && vistaPos.y <= 1 && vistaPos.z > 0) 
           {
            Instantiate(objetoGatoNegro, posicionAleatoria, Quaternion.identity);
           }
        }
        for (int i = 0; i < gatosPersaEnHabitacion; i++)
        {
           Vector3 posicionAleatoria = transform.position + Random.insideUnitSphere * rango;
           Vector3 vistaPos = camara.WorldToViewportPoint(posicionAleatoria);
        
           if(vistaPos.x >= 0 && vistaPos.x <= 1 && vistaPos.y >= 0 && vistaPos.y <= 1 && vistaPos.z > 0) 
           {
            Instantiate(objetoGatoPersa, posicionAleatoria, Quaternion.identity);
           }
        }
    }
    public void Update() 
    {
        felicidadGatosTexto.text = "Felicidad: " + $"{felicidadGatos}";
        textoGatosEnHabitacion.text = "Gatos en la habitacion: " + $"{gatosEnHabitacion}";  
        nivelHabitacion = TiendaScript.nivelHabitacionn;
    }
    

    public void Aumentar()
    {
        if(nivelHabitacion == 1)
        {
            if(gatosEnHabitacion < 4)
            {
                gatosEnHabitacion++; 
            }
        }
        if(nivelHabitacion == 2)
        {
            if(gatosEnHabitacion < 8)
            {
                gatosEnHabitacion++; 
            }
        }
        if(nivelHabitacion == 3)
        {
            if(gatosEnHabitacion < 15)
            {
                gatosEnHabitacion++; 
            }
        }
        if(nivelHabitacion == 4)
        {
            if(gatosEnHabitacion < 20)
            {
                gatosEnHabitacion++; 
            }
        }
    }
}
