using System;
using System.Collections;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public float moveAmount;

    private float enemyWait;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyWait = 1f;
        StartCoroutine(move());
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator move()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyWait);
            Vector3 pos = transform.position;
            float newX = pos.x + moveAmount;
            transform.position = new Vector3(newX, pos.y, pos.z);
            if (transform.position.x is >= 1.1f or <= -1.1f)
            {
                moveAmount = -moveAmount;
                yield return new WaitForSeconds(enemyWait);
                pos = transform.position;
                float newY = pos.y - Math.Abs(moveAmount);
                transform.position = new Vector3(pos.x, newY, pos.z);
            }
        }
    }
    void EnemyOnOnEnemyDied(int points)
    {
        enemyWait -= .02f;
        if (enemyWait < .2f)
            enemyWait = .2f;
    }
}
