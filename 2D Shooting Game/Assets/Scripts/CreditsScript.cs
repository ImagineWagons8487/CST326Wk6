using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CreditsThenMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreditsThenMenu()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("DemoScene");
    }
}
