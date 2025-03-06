using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject reference;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void LoadGameScene(string sceneName)
    {
        StartCoroutine(_LoadGameScene(sceneName));

        IEnumerator _LoadGameScene(string scene)
        {
            AsyncOperation loadOp = SceneManager.LoadSceneAsync(scene);
            while (!loadOp!.isDone) yield return null;

            // GameObject player = GameObject.Find("Player");
            // Debug.Log(player.name);
        }
    }
}
