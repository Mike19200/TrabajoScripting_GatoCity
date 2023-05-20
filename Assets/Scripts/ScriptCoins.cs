using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCoins : MonoBehaviour
{
    public static ScriptCoins Instance { get; private set; }

    public Text textoProduccionMonedasHabitacion;
    public float tiempoAumento = 5f;
    public float tiempoDisminucion = 1f;
    public float aumentoPorCiclo = 1f;
    public float disminucionPorGato = 0.5f;
    public static float produccionMonedasHabitacion = 0f;

    private float tiempoPasado = 0f;
    private float tiempoRestante = 0f;
    private float felicidadGatos = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= tiempoRestante)
        {
            tiempoPasado = 0f;
            produccionMonedasHabitacion += aumentoPorCiclo;
            tiempoRestante = tiempoAumento - felicidadGatos * tiempoDisminucion;

            if (textoProduccionMonedasHabitacion != null)
            {
                textoProduccionMonedasHabitacion.text = "GatoCoins: " + produccionMonedasHabitacion.ToString();
            }
        }
    }

    public void ActualizarFelicidadGatos(float felicidad)
    {
        felicidadGatos = felicidad;
    }
}
