using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBarrierScript : MonoBehaviour
{
    private AudioSource audioSource;
    public Sprite damaged, gone;
    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 2;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        health--;
        Destroy(other.gameObject);
        audioSource.Play();
        if (health == 1)
        {
            GetComponent<SpriteRenderer>().sprite = damaged;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
        else if (health == 0)
        {
            StartCoroutine(WaitThenDestroy());
        }
    }

    IEnumerator WaitThenDestroy()
    {
        GetComponent<SpriteRenderer>().sprite = gone;
        Destroy(GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
