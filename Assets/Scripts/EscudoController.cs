using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoController : MonoBehaviour
{
    private int direction;

    public int getDirection()
    {
        return this.direction;
    }

    public void setDirection(int valor)
    {
        this.direction = valor;
    }
}
