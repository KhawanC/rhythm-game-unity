using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoController : MonoBehaviour
{
    private int direction;
    private int speed;

    public int getDirection()
    {
        return this.direction;
    }

    public int getSpeed()
    {
        return this.speed;
    }

    public void setDirection(int valor)
    {
        this.direction = valor;
    }

    public void setSpeed(int valor)
    {
        this.speed = valor;
    }
}
