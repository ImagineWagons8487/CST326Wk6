using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    public int points = 10;

    public GameObject bulletPrefab;
    //delegate is not declaring a function, is declaring a type
    public delegate void EnemyDied(int points);

    public static event EnemyDied OnEnemyDied;

    private Animator enemyAnimator;

    // private bool dead;

    private System.Random rand;
    // Start is called before the first frame update
    private void Start()
    {
        rand = new Random();
        // dead = false;
        enemyAnimator = GetComponent<Animator>();
        StartCoroutine(shoot());
    }

    private void Update()
    {
        // enemyAnimator.SetBool("Dead", dead);
        // if (GetComponent<SpriteRenderer>().sprite.name == "0")
        // {
        //     Destroy(gameObject);
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      Destroy(collision.gameObject);
      // dead = true;
      Destroy(gameObject);
      //would call a function out to anyone who needs it, a signal? If no one signs up, it's null
      // OnEnemyDied.Invoke();
      // if (OnEnemyDied != null)
      //     OnEnemyDied.Invoke();
      //same thing ^-v
      OnEnemyDied?.Invoke(points);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator shoot()
    {
        while (true)
        {
            float randTime = (float)rand.NextDouble()*100;
            yield return new WaitForSeconds(randTime);
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
