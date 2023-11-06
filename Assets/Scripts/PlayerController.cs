using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int vidas;

    public int getVidas()
    {
        return this.vidas;
    }

    public void setVidas(int vidas)
    {
        this.vidas = vidas;
    }
}
