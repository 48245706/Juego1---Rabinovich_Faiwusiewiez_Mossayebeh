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
           
        }
    }

    void Active()
    {
        precio1 = Random.Range(0, producto1.Length);
        precio2 = Random.Range(0, producto1.Length);
        producto1[precio1].transform.position = new Vector3(6f, 0f, 0f);
        producto2[precio2].transform.position = new Vector3(-6f, 0f, 0f);
        producto1[precio1].SetActive(true);
        producto2[precio2].SetActive(true);
        int Precio1 = producto1[precio1].GetComponent<ProductoDer>().precio;
        int Precio2 = producto2[precio2].GetComponent<ProductoDer>().precio;
        TextoSimboloDePesos1.text = "$" + Precio1.ToString();
        TextoSimboloDePesos2.text = "$" + Precio2.ToString();
    }
    public void botonResponder()
    {
        Text respuestaText = respuesta.GetComponentInChildren<Text>();

        if (respuestaText != null && string.IsNullOrEmpty(respuestaText.text))
        {
            respuestaCorrecta.SetActive(false);
            respuestaIncorrecta.SetActive(false);
        }
        else if (respuestaText != null)
        {
            int Precio1 = producto1[precio1].GetComponent<ProductoDer>().precio;
            int Precio2 = producto2[precio2].GetComponent<ProductoDer>().precio;
            int precioTotal = Precio1 + Precio2;
            int respuestaUser;

            if (int.TryParse(respuestaText.text, out respuestaUser))
            {
                if (respuestaUser == precioTotal)
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
                respuestaCorrecta.SetActive(false);
                respuestaIncorrecta.SetActive(false);
            }
        }
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
