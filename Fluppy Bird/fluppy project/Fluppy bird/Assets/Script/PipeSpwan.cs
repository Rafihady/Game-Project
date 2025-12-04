using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwan : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime = 1.5f;
    [SerializeField] private float yPosMin = -1f;
    [SerializeField] private float yPosMax = 1f;

    void Start()
    {
        StartCoroutine(SpawnPipeLoop());
    }

    IEnumerator SpawnPipeLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            Vector3 spawnPos = transform.position + Vector3.up * Random.Range(yPosMin, yPosMax);
            Instantiate(pipe, spawnPos, Quaternion.identity);
        }
    }
}
