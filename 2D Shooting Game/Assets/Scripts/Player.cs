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

  public int speed;

  public Transform shottingOffset;
  public GameObject playerParent;
  public AudioClip shootSound;
  public AudioClip dieSound;
  
  private AudioSource audioSource;

  private Animator playerAnimator;
  private bool dead;
  private bool moving;
  private float t;
  private void Start()
  {
    dead = false;
    moving = false;
    t = 100;
    Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
    playerAnimator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
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
      playerAnimator.SetBool("Dead",dead);
      playerAnimator.SetBool("Moving", moving);
      t += Time.deltaTime;
      if (Input.GetKeyDown(KeyCode.Space) && t > .7f)
      {
        PlaySound(shootSound);
        playerAnimator.SetTrigger("Shoot");
        
        GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
        t = 0;
      }

      if (Input.GetKey(KeyCode.LeftArrow) && !dead)
      {
        moving = true;
        Vector3 pos = playerParent.transform.position;
        float newX = pos.x - speed * Time.deltaTime;
        playerParent.transform.position = new Vector3(newX, pos.y, pos.z);
      }
      else if (Input.GetKey(KeyCode.RightArrow) && !dead)
      {
        moving = true;
        Vector3 pos = playerParent.transform.position;
        float newX = pos.x + speed * Time.deltaTime;
        playerParent.transform.position = new Vector3(newX, pos.y, pos.z);
      }
      else
      {
        moving = false;
      }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      dead = true;
      Destroy(other.gameObject);
      StartCoroutine(WaitThenDie());
    }
    
    IEnumerator WaitThenDie()
    {
      PlaySound(dieSound);
      yield return new WaitForSeconds(2f);
      OnPlayerDied?.Invoke();
      Destroy(gameObject);
      SceneManager.LoadScene("CreditsScene");
    }

    private void PlaySound(AudioClip clip)
    {
      audioSource.clip = clip;
      audioSource.Play();
    }
}
