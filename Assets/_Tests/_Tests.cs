using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static System.Net.Mime.MediaTypeNames;

public class _Tests
{
    public class UpdateTest
    {
        [Test]
        public void Update_IncreasesProductionWhenTimeElapsed()
        {
            // Arrange
            float deltaTime = 1.0f;
            float aumentoPorCiclo = 10.0f;
            float tiempoAumento = 5.0f;
            float tiempoDisminucion = 0.5f;
            float felicidadGatos = 2.0f;
            float produccionMonedasHabitacion = 0.0f;
            float tiempoPasado = 0.0f;
            float tiempoRestante = tiempoAumento - felicidadGatos * tiempoDisminucion;

            // Act
            // Simulamos el tiempo transcurrido
            tiempoPasado += deltaTime;

            // Comprobamos si ha pasado el tiempo de aumento de producción
            if (tiempoPasado >= tiempoRestante)
            {
                tiempoPasado = 0f;
                produccionMonedasHabitacion += aumentoPorCiclo;
                tiempoRestante = tiempoAumento - felicidadGatos * tiempoDisminucion;
            }

            // Assert
            Assert.AreEqual(aumentoPorCiclo, produccionMonedasHabitacion);
            Assert.AreEqual(0f, tiempoPasado);
            Assert.AreEqual(tiempoAumento - felicidadGatos * tiempoDisminucion, tiempoRestante);
        }
    }

    public class MejorarTest
    {
        [Test]
        public void Mejorar_ShouldUpgradeRoomAndDecreaseCoinsProduction()
        {
            // Arrange
            ScriptCoins.produccionMonedasHabitacion = 200;
            AgregarGatos.nivelHabitacion = 1;
            int expectedNivelHabitacion = 2;
            float expectedProduccionMonedasHabitacion = 150;

            // Create an instance of TiendaScript
            TiendaScript tiendaScript = new TiendaScript();

            // Act
            tiendaScript.Mejorar();

            // Assert
            Assert.AreEqual(expectedNivelHabitacion, AgregarGatos.nivelHabitacion);
            Assert.AreEqual(expectedProduccionMonedasHabitacion, ScriptCoins.produccionMonedasHabitacion);
        }
    }

    public class AumentarTest
    {
        [Test]
        public void Aumentar_IncreasesCatCountAndHappiness()
        {
            // Arrange
            int gatosEnHabitacion = 3;
            int felicidadGatos = 2;
            string textoEsperado = "Gatos en la habitacion: 4";

            // Act
            AumentarGatosEnHabitacion(ref gatosEnHabitacion, ref felicidadGatos);

            // Assert
            Assert.AreEqual(4, gatosEnHabitacion);
            Assert.AreEqual(3, felicidadGatos);
            Assert.AreEqual(textoEsperado, ObtenerTextoGatosEnHabitacion(gatosEnHabitacion));
        }

        private void AumentarGatosEnHabitacion(ref int gatosEnHabitacion, ref int felicidadGatos)
        {
            if (gatosEnHabitacion < 4)
            {
                gatosEnHabitacion++;
                felicidadGatos++;
            }
        }

        private string ObtenerTextoGatosEnHabitacion(int gatosEnHabitacion)
        {
            return "Gatos en la habitacion: " + gatosEnHabitacion.ToString();
        }
    }

    public class AgregarTests
    {
        [Test]
        public void Agregar_InstantiatesCatObjectWithinRangeAndView()
        {
            // Arrange
            int gatosEnHabitacion = 3;
            Vector3 posicionHabitacion = new Vector3(0, 0, 0);
            float rango = 10f;
            GameObject[] objetosGatos = { /* objetos de gatos para instanciar */ };
            Camera camara = Camera.main;

            // Act
            AgregarGato(gatosEnHabitacion, posicionHabitacion, rango, objetosGatos, camara);

            // Assert
            // Comprobamos si se ha instanciado un objeto de gato
            GameObject[] gatosInstanciados = GameObject.FindGameObjectsWithTag("Gato");
            Assert.AreEqual(1, gatosInstanciados.Length);

            // Comprobamos si el objeto de gato está dentro del rango y en la vista de la cámara
            Vector3 posicionGatoInstanciado = gatosInstanciados[0].transform.position;
            Vector3 vistaPos = camara.WorldToViewportPoint(posicionGatoInstanciado);
            Assert.IsTrue(posicionGatoInstanciado.magnitude <= rango);
            Assert.IsTrue(vistaPos.x >= 0 && vistaPos.x <= 1 && vistaPos.y >= 0 && vistaPos.y <= 1 && vistaPos.z > 0);
        }

        private static void AgregarGato(int gatosEnHabitacion, Vector3 posicionHabitacion, float rango, GameObject[] objetosGatos, Camera camara)
        {
            if (gatosEnHabitacion < 4)
            {
                Vector3 posicionAleatoria = posicionHabitacion + Random.insideUnitSphere * rango;
                Vector3 vistaPos = camara.WorldToViewportPoint(posicionAleatoria);

                if (vistaPos.x >= 0 && vistaPos.x <= 1 && vistaPos.y >= 0 && vistaPos.y <= 1 && vistaPos.z > 0)
                {
                    int indiceAleatorio = Random.Range(0, objetosGatos.Length);
                    GameObject.Instantiate(objetosGatos[indiceAleatorio], posicionAleatoria, Quaternion.identity);
                }
            }
        }
    }
}
