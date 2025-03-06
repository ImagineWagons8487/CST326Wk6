using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int points = 10;
    //delegate is not declaring a function, is declaring a type
    public delegate void EnemyDied(int points);

    public static event EnemyDied OnEnemyDied;

    private Animator enemyAnimator;

    private bool dead;
    // Start is called before the first frame update
    private void Start()
    {
        dead = false;
        enemyAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        enemyAnimator.SetBool("Dead", dead);
        if (GetComponent<SpriteRenderer>().sprite.name == "0")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      Destroy(collision.gameObject);
      dead = true;
      
      //would call a function out to anyone who needs it, a signal? If no one signs up, it's null
      // OnEnemyDied.Invoke();
      // if (OnEnemyDied != null)
      //     OnEnemyDied.Invoke();
      //same thing ^-v
      OnEnemyDied?.Invoke(points);
    }
}
