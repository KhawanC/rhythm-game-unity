using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int vidas;
    private float pontos;
    private int streakPontos;

    public int getVidas()
    {
        return this.vidas;
    }

    public void setVidas(int vidas)
    {
        this.vidas = vidas;
    }

    public float getPontos()
    {
        return this.pontos;
    }

    public void setPontos(float pontos)
    {
        this.pontos = pontos;
    }

    public int getStreakPontuacao()
    {
        return this.streakPontos;
    }

    public void setStreakPontuacao(int streakPontuacao)
    {
        this.streakPontos = streakPontuacao;
    }
}
