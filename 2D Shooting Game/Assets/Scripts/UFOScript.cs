using System;
using UnityEngine;
using Random = System.Random;

public class UFOScript : MonoBehaviour
{
    public float moveAmount;

    public bool leftSpawned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAmount = 2f;
        if (transform.position.x < 0)
        {
            leftSpawned = true;
        }
        else
        {
            leftSpawned = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float newX = pos.x;
        if (leftSpawned)
        {
            newX += Math.Abs(moveAmount)*Time.deltaTime;
        }
        else
        {
            newX -= Math.Abs(moveAmount)*Time.deltaTime;
        }

        if (transform.position.x is < -6 or > 6)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector3(newX, pos.y, pos.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
