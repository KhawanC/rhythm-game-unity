using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    private InterfaceController interfaceController;
    [SerializeField] Text textoTemporizador;
    private string textSegundo, textMinuto, textHora;

    private void Awake()
    {
        interfaceController = gameObject.AddComponent<InterfaceController>();
    }

    void Start()
    {
        interfaceController.setPause(false);
        interfaceController.setSegundos(0);
        interfaceController.setMinutos(0);
        interfaceController.setHoras(0);
    }

    void Update()
    {
        if (!interfaceController.getPause())
        {
            if (interfaceController.getSegundos() < 60.0)
            {
                interfaceController.setSegundos(interfaceController.getSegundos() + (Time.deltaTime * 2));
            } else if (interfaceController.getSegundos() >= 60)
            {
                if (interfaceController.getMinutos() <= 60.0)
                {
                    interfaceController.setMinutos(interfaceController.getMinutos() + 1);
                    interfaceController.setSegundos(0);
                } else
                {
                    interfaceController.setHoras(interfaceController.getHoras() + 1);
                    interfaceController.setMinutos(0);
                    interfaceController.setSegundos(0);
                }
            }
        }

        textSegundo = Mathf.RoundToInt(interfaceController.getSegundos()) / 10 >= 1 ? Mathf.RoundToInt(interfaceController.getSegundos()).ToString() : "0" + Mathf.RoundToInt(interfaceController.getSegundos()).ToString();
        textMinuto = interfaceController.getMinutos() / 10 >= 1 ? interfaceController.getMinutos().ToString() : "0" + interfaceController.getMinutos().ToString();
        textHora = interfaceController.getHoras() / 10 >= 1 ? interfaceController.getHoras().ToString() : "0" + interfaceController.getHoras().ToString();

        textoTemporizador.text = textHora  + ":" + textMinuto + ":" + textSegundo;
    }
}
