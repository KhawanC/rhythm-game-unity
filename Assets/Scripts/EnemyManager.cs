using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyController enemy;
    private Vector3 vectorDirection = Vector3.up;
    private PlayerManager playerManager;

    private void Awake()
    {
        enemy = new EnemyController();
        calcularDirecao();
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    void Start()
    {
        enemy.setVelocidade(8);
        calcularDirecao();
        Debug.Log(transform.position);

    }

    void Update()
    {
        transform.position += (vectorDirection * enemy.getVelocidade()) * Time.deltaTime;
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
            GameObject.Destroy(gameObject);
            playerManager.receberDano(1);
        } else if (collision.gameObject.tag == "escudo")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
