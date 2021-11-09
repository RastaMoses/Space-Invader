using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 5f;
    [SerializeField] Enemy enemy;
    [SerializeField] Vector2 minMaxSpawnHeight;
    [SerializeField] int enemyLimit = 8;
    bool enemyLimitReached;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        if (!enemyLimitReached)
        {
            Instantiate(enemy, new Vector3(transform.position.x, Random.Range(minMaxSpawnHeight.x, minMaxSpawnHeight.y), 0), Quaternion.identity);
        }
        if (FindObjectsOfType<Enemy>().Length > enemyLimit)
        {
            enemyLimitReached = true;
        }
        else
        {
            enemyLimitReached = false;
        }
        yield return new WaitForSeconds(spawnRate);
        yield return Spawn();
    }
}
