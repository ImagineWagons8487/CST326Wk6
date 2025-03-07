using System.IO;
using TMPro;
using UnityEngine;

public class GamePointsScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int currentScore;

    private int highScore;

    private string filePath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        UFOScript.OnUFODied += UFOOnOnUFODied;
        Player.OnPlayerDied += PlayerOnOnPlayerDied;
        currentScore = 0;
        filePath = Application.dataPath + "/HiScore.txt";
        highScore = int.Parse(File.ReadAllLines(filePath)[0]);
    }

    private void UFOOnOnUFODied(int points)
    {
        EnemyOnOnEnemyDied(points);
    }

    private void PlayerOnOnPlayerDied()
    {
        //write to txt file to update high score
        if (highScore < currentScore)
            highScore = currentScore;
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, highScore.ToString());
        }
        else
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(highScore.ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnemyOnOnEnemyDied(int points)
    {
        currentScore += points;
        string s = currentScore.ToString();
        while (s.Length < 4)
        {
            s = "0" + s;
        }

        text.text = "SCORE\n" + s;
    }
    

}
