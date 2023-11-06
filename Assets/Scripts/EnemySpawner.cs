using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float timer = 0;
    private float intervaloSpawn = 1.0f;
    [SerializeField] GameObject seta;

    void Start()
    {
        spawnarSeta();
    }

    void Update()
    {
        if(timer < intervaloSpawn)
        {
            timer += Time.deltaTime;
        } else
        {
            spawnarSeta();
            timer = 0;
        }
    }

    private void spawnarSeta()
    {
        int randomDirection = Random.Range(0, 4);
        int spawnX = 0;
        int spawnY = 0;
        if (randomDirection == 0)
        {
            spawnY = 6;
        } else if (randomDirection == 1)
        {
            spawnX = 8;
        } else if (randomDirection == 2)
        {
            spawnY = -6;
        } else if (randomDirection == 3)
        {
            spawnX = -8;
        }
        Instantiate(seta, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(new Vector3(0,0,0)));
    }
}
