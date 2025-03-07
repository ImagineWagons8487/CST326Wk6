using System;
using UnityEngine;
using Random = System.Random;

public class UFOScript : MonoBehaviour
{
    public float moveAmount;

    public bool leftSpawned;
<<<<<<< HEAD

=======
    
>>>>>>> e451b9da3db0dff3b749a8de07991b73b8b09f22
    public delegate void UFODied(int points);

    public static event UFODied OnUFODied;
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
        Random rand = new Random();
        int points;
        switch (rand.Next() % 3)
        {
            case 0:
                points = 150;
                break;
            case 1:
                points = 200;
                break;
            case 2:
                points = 350;
                break;
            default:
                points = 150;
                break;
        }
        OnUFODied?.Invoke(points);
        Destroy(other.gameObject);
        Destroy(gameObject);
<<<<<<< HEAD
}
=======
    }
>>>>>>> e451b9da3db0dff3b749a8de07991b73b8b09f22
}
