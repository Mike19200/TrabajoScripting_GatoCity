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

        // Iniciar la producción extra en el inicio del juego
        produccionExtraActivada = true;
    }

    private void Update()
    {
        // Actualizar el tiempo pasado
        tiempoPasado += Time.deltaTime;

        // Si ha pasado el tiempo de producción extra
        if (tiempoPasado >= tiempoProduccionExtra)
        {
            tiempoPasado = 0f;

            // Activar la producción extra
            produccionExtraActivada = true;
        }

        // Si la producción extra está activada
        if (produccionExtraActivada && scriptCoins != null)
        {
            // Aumentar la producción de monedas habitación en el script ScriptCoins
            scriptCoins.produccionMonedasHabitacion += cantidadMonedasExtra;

            // Actualizar el texto de producción de monedas habitación en el script ScriptCoins
            if (scriptCoins.textoProduccionMonedasHabitacion != null)
            {
                scriptCoins.textoProduccionMonedasHabitacion.text = "GatoCoins: " + scriptCoins.produccionMonedasHabitacion.ToString();
            }

            // Reiniciar la producción extra
            produccionExtraActivada = false;
        }
    }
}