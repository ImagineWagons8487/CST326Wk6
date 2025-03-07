using System.Collections;
using UnityEngine;

public class UFOSpawnScript : MonoBehaviour
{
    public Transform leftSpawn, rightSpawn;
    public GameObject ufoPrefab;
    private System.Random rand = new System.Random();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnUFO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnUFO()
    {
        while (true)
        {
            float waitTime = (float)rand.NextDouble() * 5 + 10f;
            Debug.Log(waitTime);
            yield return new WaitForSeconds(waitTime);
            bool left = rand.Next() % 2 == 0;
            GameObject ufo;
            if (left)
            {
                ufo = Instantiate(ufoPrefab, leftSpawn.position, Quaternion.identity);
                
            }
            else
            {
                ufo = Instantiate(ufoPrefab, rightSpawn.position, Quaternion.identity);
            }

        }
    }
}
