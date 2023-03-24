using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GatoCity : MonoBehaviour
{
    public Text dineroTexto;
    public Text habitacionesTexto;
    public Text gatosTexto;
    public GameObject habitacionBasicaPrefab;
    public GameObject habitacionDeluxePrefab;
    public GameObject gatoPrefab;
    public Transform habitacionesParent;
    public Transform gatosParent;

    private int dinero = 10000;
    private List<Habitacion> habitaciones = new List<Habitacion>();
    private List<Gato> gatos = new List<Gato>();

    void Start()
    {
        // Inicialización del juego
        dineroTexto.text = "Dinero: " + dinero;
        habitacionesTexto.text = "Habitaciones: " + habitaciones.Count;
        gatosTexto.text = "Gatos: " + gatos.Count;
    }

    void Update()
    {
        // Actualización del estado del juego
        foreach (Habitacion habitacion in habitaciones)
        {
            habitacion.ActualizarEstado(gatos);
        }
    }

    public void ComprarHabitacion(int tipo)
    {
        if (dinero >= Habitacion.Precio(tipo))
        {
            dinero -= Habitacion.Precio(tipo);
            GameObject habitacionPrefab = tipo == 1 ? habitacionBasicaPrefab : habitacionDeluxePrefab;
            GameObject habitacionObject = Instantiate(habitacionPrefab, habitacionesParent);
            Habitacion habitacion = habitacionObject.GetComponent<Habitacion>();
            habitaciones.Add(habitacion);
            dineroTexto.text = "Dinero: " + dinero;
            habitacionesTexto.text = "Habitaciones: " + habitaciones.Count;
        }
    }

    public void ComprarGato(string nombre)
    {
        if (dinero >= Gato.Precio)
        {
            dinero -= Gato.Precio;
            GameObject gatoObject = Instantiate(gatoPrefab, gatosParent);
            Gato gato = gatoObject.GetComponent<Gato>();
            gato.Nombre = nombre;
            gatos.Add(gato);
            dineroTexto.text = "Dinero: " + dinero;
            gatosTexto.text = "Gatos: " + gatos.Count;
        }
    }
}

public class Habitacion : MonoBehaviour
{
    public int tipo;
    public Text estadoTexto;

    private int estado = 100;

    public static int Precio(int tipo)
    {
        if (tipo == 1)
        {
            return 1000;
        }
        else if (tipo == 2)
        {
            return 5000;
        }
        else
        {
            return 0;
        }
    }

    public void ActualizarEstado(List<Gato> gatos)
    {
        // Actualizar el estado de la habitación en función de la felicidad de los gatos que viven en ella
        int felicidadTotal = 0;
        int gatosEnLaHabitacion = 0;

        foreach (Gato gato in gatos)
        {
            if (gato.Habitacion == this)
            {
                felicidadTotal += gato.NivelFelicidad;
                gatosEnLaHabitacion++;
            }
        }

        int felicidadPromedio = gatosEnLaHabitacion == 0 ? 0 : felicidadTotal / gatosEnLaHabitacion;

        estado = Mathf.Max(0, Mathf.Min(100, estado + felicidadPromedio - 50));
        estadoTexto.text = "Estado: " + estado;

        // Si el estado de la habitación es demasiado bajo, puede haber un problema que necesita ser solucionado
        if (estado < 30)
        {
            SolucionarProblema();
        }
    }

    private void SolucionarProblema()
    {
        // Solucionar un problema de la habitación
        // Por ejemplo, limpiar la habitación, cambiar la ropa de cama, etc.
    }
}

public class Gato : MonoBehaviour
{
    public string Nombre { get; set; }
    public int NivelFelicidad { get; set; }
    public Habitacion Habitacion { get; set; }

    public static int Precio = 100;

    void Start()
    {
        // Inicialización del gato
        NivelFelicidad = 50;
        Habitacion = null;
    }

    void Update()
    {
        // Actualización del estado del gato
        if (Habitacion != null)
        {
            NivelFelicidad = Mathf.Max(0, Mathf.Min(100, NivelFelicidad + Habitacion.tipo));
        }
    }

    public void Moverse(Habitacion nuevaHabitacion)
    {
        // Mover al gato a una nueva habitación
        if (Habitacion != null)
        {
            Habitacion.gameObject.SendMessage("GatoSalio", this);
        }

        Habitacion = nuevaHabitacion;

        if (Habitacion != null)
        {
            Habitacion.gameObject.SendMessage("GatoEntro", this);
        }
    }
}