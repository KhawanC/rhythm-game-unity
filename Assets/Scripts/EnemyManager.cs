using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyController enemy;
    private Vector3 vectorDirection = Vector3.up;
    private PlayerManager playerManager;
    private EnemySpawner enemySpawner;
    private float intervaloAleat = 0.4f;
    private float timer = 0;
    private bool isImpulsoAtivado = false;

    private void Awake()
    {
        enemy = gameObject.AddComponent<EnemyController>();
        calcularDirecao();
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    void Start()
    {
        enemy.setVelocidade(1.8f);
        calcularDirecao();
    }

    void Update()
    {
        if (timer < intervaloAleat)
        {
            timer += Time.deltaTime;
        } else
        {
            if (Random.Range(0, 100) > 85 && !isImpulsoAtivado)
            {
                enemy.setVelocidade(enemy.getVelocidade() + 3.5f);
            }
            isImpulsoAtivado = true;
        }
        transform.position += (vectorDirection * (enemy.getVelocidade() + calcularMultiplicadorVelocidade())) * Time.deltaTime;
    }

    private float calcularMultiplicadorVelocidade()
    {
        float streak = playerManager.getStreakPontuacao();
        float pontuacao = playerManager.getPontuacao();
        float somadorVelocidade = 0;
        if (streak <= 30)
        {
            somadorVelocidade += 0.8f;
        } else if (streak <= 60)
        {
            somadorVelocidade += 1.1f;
        } else if (streak <= 90)
        {
            somadorVelocidade += 1.4f;
        } else if (streak <= 160)
        {
            somadorVelocidade += 1.8f;
        } else if (streak <= 180)
        {
            somadorVelocidade += 2f;
        } else
        {
            somadorVelocidade += 2.6f;
        }

        if (pontuacao <= 800)
        {
            somadorVelocidade += 0.7f;
        } else if (pontuacao <= 1700)
        {
            somadorVelocidade += 1.2f;
        } else if (pontuacao <= 3000)
        {
            somadorVelocidade += 1.6f;
        } else if (pontuacao <= 4500)
        {
            somadorVelocidade += 1.8f;
        }
        else if (pontuacao <= 6000)
        {
            somadorVelocidade += 2f;
        }
        else if (pontuacao <= 8000)
        {
            somadorVelocidade += 2.3f;
        }
        else if (pontuacao <= 12000)
        {
            somadorVelocidade += 2.5f;
        }
        else if (pontuacao <= 2000)
        {
            somadorVelocidade += 2.9f;
        } else
        {
            somadorVelocidade += 3.3f;
        }

        return somadorVelocidade;
    }

    private void calcularDirecao()
    {
        float spawnX = transform.position.x;
        float spawnY = transform.position.y;

        if (spawnX == 8)
        {
            enemy.setDirecao(1);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        } else if (spawnX == -8)
        {
            enemy.setDirecao(3);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        } else if (spawnY == 6)
        {
            enemy.setDirecao(0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        } else if (spawnY == -6)
        {
            enemy.setDirecao(2);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (enemy.getDirecao() == 0)
        {
            vectorDirection = Vector3.down;
        } else if (enemy.getDirecao() == 1)
        {
            vectorDirection = Vector3.left;
        } else if (enemy.getDirecao() == 2)
        {
            vectorDirection = Vector3.up;
        } else if (enemy.getDirecao() == 3)
        {
            vectorDirection = Vector3.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerManager.resetarStreakPontuacao();
            playerManager.receberDano(1);
            destruirObjeto();
        } else if (collision.gameObject.tag == "escudo")
        {
            playerManager.aumentarStreak();
            playerManager.aumentarPontuacao();
            destruirObjeto();
        }
        
    }

    private void destruirObjeto()
    {
        GameObject.Destroy(gameObject);
    }
}
