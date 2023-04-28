using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCoins : MonoBehaviour
{
   // Declaración de variables

    public Text textoProduccionMonedasHabitacion; // Variable para el objeto de texto
    public float tiempoAumento = 5f;
    public float tiempoDisminucion = 1f;
    public float aumentoPorCiclo = 1f;
    public float disminucionPorGato = 0.5f;
    public float produccionMonedasHabitacion = 0f;

    private float tiempoPasado = 0f;
    private float tiempoRestante = 0f;
    private float felicidadGatos = 0f;

    void Update()
    {
        // Actualizar el tiempo pasado
        tiempoPasado += Time.deltaTime;

        // Si ha pasado el tiempo de aumento de producción
        if (tiempoPasado >= tiempoRestante)
        {
            tiempoPasado = 0f;

            // Aumentar la producción
            produccionMonedasHabitacion += aumentoPorCiclo;

            // Disminuir el tiempo para el próximo aumento de producción
            tiempoRestante = tiempoAumento - felicidadGatos * tiempoDisminucion;

          if (textoProduccionMonedasHabitacion != null)
          {
            textoProduccionMonedasHabitacion.text = "GatoCoins: " + produccionMonedasHabitacion.ToString();
          }
        }
    }

    // Método para actualizar la felicidad de los gatos
    public void ActualizarFelicidadGatos(float felicidad)
    {
        felicidadGatos = felicidad;
    }
    
    void Awake()
    {
        // Asegurarse de que el objeto no se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }
}
