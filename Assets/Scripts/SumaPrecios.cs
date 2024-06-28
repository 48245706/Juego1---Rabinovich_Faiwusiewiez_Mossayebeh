using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SumaPrecios : MonoBehaviour
{
    public GameObject[] producto1;
    public GameObject[] producto2;
    public Text TextoSimboloDeSuma;
    public Text TextoSimboloDePesos1;
    public Text TextoSimboloDePesos2;
    public InputField InputFieldParaIngresarNumero;
    public GameObject respuesta;
    public GameObject respuestaCorrecta;
    public GameObject respuestaIncorrecta;
    int precio1;
    int precio2;
    int Precio1;
    int Precio2;

    void Start()
    {
        DeactivateAll();
        Activate();
    }

    void Update()
    {
      

    }
    void DeactivateAll()
    {
        foreach(GameObject g1 in producto1)
        {
            g1.SetActive(false);
        }
        foreach(GameObject g2 in producto2)
        {
            g2.SetActive(false);
        }
    }
    void Activate()
    {
        precio1 = Random.Range(0, producto1.Length);
        precio2 = Random.Range(0, producto2.Length);
        producto1[precio1].transform.position = new Vector3(6f, 0f, 0f);
        producto2[precio2].transform.position = new Vector3(-6f, 0f, 0f);
        producto1[precio1].SetActive(true);
        producto2[precio2].SetActive(true);
        Precio1 = producto1[precio1].GetComponent<ProductoDer>().precio;
        Precio2 = producto2[precio2].GetComponent<ProductoDer>().precio;
        Debug.Log("Precio 1 : " + Precio1 + " Precio 2 : " + Precio2);
        TextoSimboloDePesos1.text = "$" + Precio1.ToString();
        TextoSimboloDePesos2.text = "$" + Precio2.ToString();

        Debug.Log(gameObject.name);
    }
    
    public void otonResponder()
    {
        Debug.Log("Botón Responder presionado");

        string respuestaText = InputFieldParaIngresarNumero.text;
        int numeroIngreso = int.Parse(respuestaText);

        Debug.Log("Texto de respuesta: " + numeroIngreso);

        if (string.IsNullOrEmpty(respuestaText))
        {
            Debug.Log("Respuesta está vacía");
            respuestaCorrecta.SetActive(false);
            respuestaIncorrecta.SetActive(false);
        }
        else
        {
            int precioTotal = Precio1 + Precio2;
            Debug.Log("Precio Total: " + precioTotal);

                Debug.Log("Respuesta del usuario: " + numeroIngreso);
                if (numeroIngreso == precioTotal)
                {
                    Debug.Log("Respuesta Correcta");
                    respuestaCorrecta.SetActive(true);
                    respuestaIncorrecta.SetActive(false);
                }
                else
                {
                    Debug.Log("Respuesta Incorrecta");
                    respuestaCorrecta.SetActive(false);
                    respuestaIncorrecta.SetActive(true);
                }

        }
    }

    public void botonVolverAIntentar()
    {
        respuestaIncorrecta.SetActive(false);
        InputFieldParaIngresarNumero.text = "";
        DeactivateAll();
        Activate();
    }

    void botonSalir()
    {
        SceneManager.LoadScene("Seleccionar Juegos");
    }

    public void botonReiniciar()
    {
        respuestaCorrecta.SetActive(false);
        InputFieldParaIngresarNumero.text = "";
        DeactivateAll();
        Activate();
    }
}
