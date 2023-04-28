using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruir : MonoBehaviour
{
    void Awake()
    {
        // Asegurarse de que el objeto no se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }
}
