using System;
using UnityEngine;
using UnityEngine.Rendering;

public class RBarrierScript : MonoBehaviour
{
    public Sprite damaged;
    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        health--;
        Destroy(other.gameObject);
        if (health == 1)
        {
            GetComponent<SpriteRenderer>().sprite = damaged;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
        else if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
