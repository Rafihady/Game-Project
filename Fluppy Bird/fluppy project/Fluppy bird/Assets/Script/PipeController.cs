using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public static float pipeSpeed = 1.5f;
    [SerializeField] private float destroyX = -5f;

    void Update()
    {
        transform.Translate(Vector2.left * pipeSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
