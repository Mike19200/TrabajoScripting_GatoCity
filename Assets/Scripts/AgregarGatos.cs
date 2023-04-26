using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgregarGatos : MonoBehaviour
{
    public int gatosEnHabitacion = 0; // La variable que queremos aumentar
    public Text textoGatosEnHabitacion; // Texto que muestra la variable en la interfaz de usuario
    public GameObject[] objetosGatos; // Aquí asignas el GameObject que quieres agregar desde el Inspector

    public int cantidadObjetos = 10; // Aquí defines la cantidad de objetos que quieres agregar
    public float rango = 10f; // Aquí defines el rango de distancia alrededor del botón donde los objetos serán colocados


    public void Agregar()
    {
        for (int i = 0; i < cantidadObjetos; i++)
        {
            Vector3 posicionAleatoria = transform.position + Random.insideUnitSphere * rango;
            int indiceAleatorio = Random.Range(0, objetosAagregar.Length);
            Instantiate(objetosAagregar[indiceAleatorio], posicionAleatoria, Quaternion.identity);
        }
    }

    // Método que se ejecuta cuando se presiona el botón
    public void Aumentar()
    {
        variable++; // Aumentar la variable en uno
        textoGatosEnHabitacion.text = "Gatos en la habitacion: " + variable.ToString(); // Actualizar el texto de la variable
    }
}
