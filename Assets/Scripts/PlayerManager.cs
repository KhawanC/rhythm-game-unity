using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    private PlayerController player;
    private EscudoController escudo;
    [SerializeField] Text vidasTexto;
    [SerializeField] Text pontosTexto;
    [SerializeField] Text streakText;

    private void Awake()
    {
        player = gameObject.AddComponent<PlayerController>();
        escudo = gameObject.AddComponent<EscudoController>();
    }

    void Start()
    {
        player.setVidas(3);
        player.setPontos(0);
        player.setStreakPontuacao(0);
    }

    
    void Update()
    {
        vidasTexto.text = player.getVidas().ToString();
        pontosTexto.text = Math.Round(player.getPontos()).ToString() + "x";
        streakText.text = player.getStreakPontuacao().ToString();
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        } else if (Input.GetKeyDown(KeyCode.S) == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        } else if (Input.GetKeyDown(KeyCode.D) == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        } else if (Input.GetKeyDown(KeyCode.A) == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
    }

    public void receberDano(int dano)
    {
        player.setVidas(player.getVidas() - dano);
    }

    public void aumentarPontuacao()
    {
        player.setPontos(player.getPontos() + (player.getStreakPontuacao() / (100 + player.getStreakPontuacao() / player.getPontos())) + player.getStreakPontuacao());
    }

    public void aumentarStreak()
    {
        player.setStreakPontuacao(player.getStreakPontuacao() + 1);
    }

    public void resetarStreakPontuacao()
    {
        player.setStreakPontuacao(0);
    }

    public int getStreakPontuacao()
    {
        return player.getStreakPontuacao();
    }
    public float getPontuacao()
    {
        return player.getPontos();
    }
}
