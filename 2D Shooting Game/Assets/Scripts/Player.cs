using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
  public delegate void playerDied();

  public static event playerDied OnPlayerDied;
  [FormerlySerializedAs("bullet")] 
  public GameObject bulletPrefab;

  public Transform shottingOffset;

  private Animator playerAnimator;
  private void Start()
  {
    Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
    playerAnimator = GetComponent<Animator>();
  }

  void EnemyOnOnEnemyDied(int points)
  {
    // Debug.Log($"Enemy Died!!! For {points}");
  }

  private void OnDestroy()
  {
    Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
  }

  // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        playerAnimator.SetTrigger("Shoot");
        
        GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
      }

      if (Input.GetKey(KeyCode.LeftArrow))
      {
        Vector3 pos = transform.position;
        float newX = pos.x - 2 * Time.deltaTime;
        transform.position = new Vector3(newX, pos.y, pos.z);
      }
      if (Input.GetKey(KeyCode.RightArrow))
      {
        Vector3 pos = transform.position;
        float newX = pos.x + 2 * Time.deltaTime;
        transform.position = new Vector3(newX, pos.y, pos.z);
      }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      Debug.Log("Player died");
      OnPlayerDied?.Invoke();
      Destroy(other.gameObject);
      Destroy(gameObject);
      SceneManager.LoadScene("DemoScene");
    }
}
