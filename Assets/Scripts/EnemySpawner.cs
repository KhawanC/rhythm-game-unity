using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float timerSpawn = 0;
    private float intervaloSpawn = 3f;
    private float timerVelocicade = 0;
    private float intervaloVelocidade = 3f;
    private float timerReset = 0;
    private float intervaloReset = 210f;


    [SerializeField] GameObject seta;

    void Start()
    {
        spawnarSeta();
    }

    void Update()
    {
        if(timerSpawn < intervaloSpawn)
        {
            timerSpawn += Time.deltaTime;
        } else
        {
            spawnarSeta();
            timerSpawn = 0;
        }

        if (timerVelocicade < intervaloVelocidade)
        {
            timerVelocicade += Time.deltaTime;
        }
        else
        {
            if (intervaloSpawn >= 0.8f)
            {
                intervaloSpawn -= 0.03f;
            }
            timerVelocicade = 0;
        }

        if (timerReset < intervaloReset)
        {
            timerReset += Time.deltaTime;
        }
        else
        {
            intervaloSpawn = 2.3f;
            timerVelocicade = 0;
        }
    }

    private void spawnarSeta()
    {
        int randomDirection = Random.Range(0, 8);
        int spawnX = 0;
        int spawnY = 0;
        if (randomDirection == 0 || randomDirection == 4)
        {
            spawnY = 6;
        } else if (randomDirection == 1 || randomDirection == 5)
        {
            spawnX = 8;
        } else if (randomDirection == 2 || randomDirection == 6)
        {
            spawnY = -6;
        } else if (randomDirection == 3 || randomDirection == 7)
        {
            spawnX = -8;
        }
        Instantiate(seta, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(new Vector3(0,0,0)));
    }
}
