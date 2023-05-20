using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgregarGatos : MonoBehaviour
{
    public int gatosEnHabitacion = 0; 
    public float felicidadGatos = 0;

    public static int nivelHabitacion = 1;
    public Text textoGatosEnHabitacion; 
    public Text felicidadGatosTexto; 
    public GameObject[] objetosGatos; 
    public Camera camara;

    public float rango = 1f; 
    public float velocidadAumentoFelicidad = 0.0000005f;

    public void Start() 
    {
        nivelHabitacion = TiendaScript.nivelHabitacionn;
    }
    public void Update() 
    {
        felicidadGatosTexto.text = "Felicidad: " + $"{felicidadGatos}";
        textoGatosEnHabitacion.text = "Gatos en la habitacion: " + $"{gatosEnHabitacion}";  
        felicidadGatos += gatosEnHabitacion * velocidadAumentoFelicidad;
        nivelHabitacion = TiendaScript.nivelHabitacionn;
    }
    public void Agregar()
    { 
        if(gatosEnHabitacion < 4)
        {
           Vector3 posicionAleatoria = transform.position + Random.insideUnitSphere * rango;
           Vector3 vistaPos = camara.WorldToViewportPoint(posicionAleatoria);
        
           if(vistaPos.x >= 0 && vistaPos.x <= 1 && vistaPos.y >= 0 && vistaPos.y <= 1 && vistaPos.z > 0) 
           {
            int indiceAleatorio = Random.Range(0, objetosGatos.Length);
            Instantiate(objetosGatos[indiceAleatorio], posicionAleatoria, Quaternion.identity);
           }
        }
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
