using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawn : MonoBehaviour
{
    [SerializeField] GameObject cometPrefab;
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] float speed = 5f;

    GameObject comet;

    float spawnTime = 50;

    private void Start()
    {
        SpawnComet();
    }

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0);

        spawnTime += Time.deltaTime;

        if(spawnTime >= 60)
        {
                spawnTime = 0f;
                SpawnComet();
        }
    }

    void SpawnComet()
    {
        comet = Instantiate(cometPrefab, start.position, Quaternion.identity);
        comet.GetComponent<Comet>().start = start;
        comet.GetComponent<Comet>().end = end;
    }
}
