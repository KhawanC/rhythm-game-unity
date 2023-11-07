using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int direcao;
    private float velocidade;

    public float getVelocidade()
    {
        return this.velocidade;
    }

    public void setVelocidade(float velocidade)
    {
        this.velocidade = velocidade;
    }

    public int getDirecao()
    {
        return this.direcao;
    }

    public void setDirecao(int direcao)
    {
        this.direcao = direcao;
    }
}
