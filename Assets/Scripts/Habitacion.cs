using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimnasio : Habitacion
{
    public static int Precio = 500;
    public static int BonusFelicidad = 10;

    private void Awake()
    {
        tipo = 0;
        tiempoEntreActualizaciones = 5.0f;
        costoMantenimiento = 20;
        estado = 100;
    }

    protected virtual void ActualizarEstado()
    {
        base.ActualizarEstado();

        // Aumentar la felicidad de los gatos que utilizan el gimnasio
        foreach (Gato gato in gatosEnHabitacion)
        {
            gato.NivelFelicidad += BonusFelicidad;
        }
    }
}