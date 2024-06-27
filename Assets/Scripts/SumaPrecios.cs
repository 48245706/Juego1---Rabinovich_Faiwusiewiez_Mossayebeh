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
    public GameObject inputVacio;
    int factorIzquierdo;
    int factorDerecho;
    // Start is called before the first frame update
    void Start()
    {
        DeactivateAll();
        Active();
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    void DeactivateAll()
    {
        for(int i=0; i < producto1.Length; i++)
        {
            producto1[i].SetActive(false);
            producto2[i].SetActive(false);
            respuestaIncorrecta.SetActive(false);
            respuestaCorrecta.SetActive(false);
            inputVacio.SetActive(false);
        }
    }

    void Active()
    {
        factorIzquierdo = Random.Range(0, producto1.Length);
        factorDerecho = Random.Range(0, producto1.Length);
        producto1[factorIzquierdo].transform.position = new Vector3(6f, 0f, 0f);
        producto2[factorDerecho].transform.position = new Vector3(-6f, 0f, 0f);
        producto1[factorIzquierdo].SetActive(true);
        producto2[factorDerecho].SetActive(true);
        int Precio1 = producto1[factorIzquierdo].GetComponent<ProductoDer>().precio;
        int Precio2 = producto2[factorDerecho].GetComponent<ProductoDer>().precio;
        TextoSimboloDePesos1.text = "$" + Precio1.ToString();
        TextoSimboloDePesos2.text = "$" + Precio2.ToString();
    }
    public void botonResponder()
    {
        Text respuestaText = respuesta.GetComponentInChildren<Text>();

        if (respuestaText != null && respuestaText.text == "")
        //if (respuesta.text == "") //me tiraba error text
        {
            inputVacio.SetActive(true);
            respuestaCorrecta.SetActive(false);
            respuestaIncorrecta.SetActive(false);
        }
        else if(respuestaText != null)
        {
            inputVacio.SetActive(false);
            int Precio1 = producto1[factorIzquierdo].GetComponent<ProductoDer>().precio;
            int Precio2 = producto2[factorDerecho].GetComponent<ProductoDer>().precio;
            int precioTotal = Precio1 + Precio2;
            int respuestaUser;

            if(int.TryParse(respuestaText.text, out respuestaUser))
            {
                if(respuestaUser == precioTotal)
                {
                    respuestaCorrecta.SetActive(true);
                    respuestaIncorrecta.SetActive(false);
                }
                else
                {
                    respuestaCorrecta.SetActive(false);
                    respuestaIncorrecta.SetActive(true);
                }
            }
            else
            {
                inputVacio.SetActive(true);
                respuestaCorrecta.SetActive(false);
                respuestaIncorrecta.SetActive(false);
            }
        }
    }

    void botonCerrar()
    {
        inputVacio.SetActive(false);
    }

    public void botonVolverAIntentar()
    {
        respuestaIncorrecta.SetActive(false);
    }

    void botonSalir()
    {
        SceneManager.LoadScene("Seleccionar Juegos");
    }

    public void botonReiniciar()
    {
        SceneManager.LoadScene("Juego");
    }

}
