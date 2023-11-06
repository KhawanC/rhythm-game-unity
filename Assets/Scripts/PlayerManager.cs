using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    private PlayerController player;
    private EscudoController escudo;
    [SerializeField] Text pontuacao;

    private void Awake()
    {
        player = new PlayerController();
        escudo = new EscudoController();
    }

    void Start()
    {
        player.setVidas(20);
        escudo.setSpeed(5);
    }

    
    void Update()
    {
        pontuacao.text = player.getVidas().ToString();
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
}
