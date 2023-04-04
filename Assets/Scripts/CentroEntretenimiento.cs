using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroDeEntretenimiento : Habitacion
{ 
    public static int Precio = 1000;
    public static int BonusFelicidad = 20;

    private void Awake()
    {
        tipo = 1;
        tiempoEntreActualizaciones = 10.0f;
        costoMantenimiento = 40;
        estado = 100;
    }

    protected override void ActualizarEstado()
    {
        base.ActualizarEstado();

        // Aumentar la felicidad de los gatos que utilizan el centro de entretenimiento
        foreach (Gato gato in gatosEnHabitacion)
        {
            gato.NivelFelicidad += BonusFelicidad;
        }
    }
}
