using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgregarGatos : MonoBehaviour
{
    public int gatosEnHabitacion = 0; 
    public Text textoGatosEnHabitacion; 
    public GameObject[] objetosGatos; 
    public Camera camara;

    public float rango = 1f; 


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
        if(gatosEnHabitacion < 4)
        {
           gatosEnHabitacion++; 
           textoGatosEnHabitacion.text = "Gatos en la habitacion: " + gatosEnHabitacion.ToString();  
        }
    }
}
