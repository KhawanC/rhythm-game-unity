using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    private float segundos;
    private int minutos;
    private int horas;
    private bool isPause;

    public float getSegundos()
    {
        return this.segundos;
    }

    public int getMinutos()
    {
        return this.minutos;
    }

    public int getHoras()
    {
        return this.horas;
    }

    public void setSegundos(float segundos)
    {
        this.segundos = segundos;
    }

    public void setMinutos(int minutos)
    {
        this.minutos = minutos;
    }

    public void setHoras(int horas)
    {
        this.horas = horas;
    }

    public bool getPause()
    {
        return this.isPause;
    }

    public void setPause(bool pause)
    {
        this.isPause = pause;
    }
}
