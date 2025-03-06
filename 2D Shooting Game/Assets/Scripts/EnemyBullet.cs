using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
        StartCoroutine(waitThenDestroy());
    }

    // Update is called once per frame
    private void Fire()
    {
        myRigidbody2D.linearVelocity = Vector2.down * speed; 
    }

    IEnumerator waitThenDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
