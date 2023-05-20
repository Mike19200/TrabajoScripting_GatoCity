using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoNegro : MonoBehaviour
{
    private ScriptCoins scriptCoins; // Referencia al script ScriptCoins

    [SerializeField] private float tiempoProduccionExtra = 3600f;
    [SerializeField] private int cantidadMonedasExtra = 50;

    private float tiempoPasado = 0f;
    private bool produccionExtraActivada = false;

    private void Start()
    {
        // Obtener la referencia al script ScriptCoins en el mismo objeto o en cualquier objeto en la escena
        scriptCoins = FindObjectOfType<ScriptCoins>();

        // Iniciar la producci�n extra en el inicio del juego
        produccionExtraActivada = true;
    }

    private void Update()
    {
        // Actualizar el tiempo pasado
        tiempoPasado += Time.deltaTime;

        // Si ha pasado el tiempo de producci�n extra
        if (tiempoPasado >= tiempoProduccionExtra)
        {
            tiempoPasado = 0f;

            // Activar la producci�n extra
            produccionExtraActivada = true;
        }

        // Si la producci�n extra est� activada
        if (produccionExtraActivada && scriptCoins != null)
        {
            // Aumentar la producci�n de monedas habitaci�n en el script ScriptCoins
            scriptCoins.produccionMonedasHabitacion += cantidadMonedasExtra;

            // Actualizar el texto de producci�n de monedas habitaci�n en el script ScriptCoins
            if (scriptCoins.textoProduccionMonedasHabitacion != null)
            {
                scriptCoins.textoProduccionMonedasHabitacion.text = "GatoCoins: " + scriptCoins.produccionMonedasHabitacion.ToString();
            }

            // Reiniciar la producci�n extra
            produccionExtraActivada = false;
        }
    }
}