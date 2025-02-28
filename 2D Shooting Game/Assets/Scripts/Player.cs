using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
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
    Debug.Log($"Enemy Died!!! For {points}");
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
        Debug.Log("Bang!");
      }
    }
}
