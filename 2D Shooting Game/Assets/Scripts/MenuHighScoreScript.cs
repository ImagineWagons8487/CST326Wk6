using System.IO;
using TMPro;
using UnityEngine;

public class MenuHighScoreScript : MonoBehaviour
{
    private string filePath;

    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filePath = Application.dataPath + "/HiScore.txt";
        string s = File.ReadAllText(filePath);
        for (int i = 0; i < s.Length; ++i)
        {
            Debug.Log($"\"{s[i]}\"");
        }
        while (s.Length < 4)
        {
            s = '0' + s;
            Debug.Log(s);
        }
        text.text = "HI-SCORE\n" + s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
