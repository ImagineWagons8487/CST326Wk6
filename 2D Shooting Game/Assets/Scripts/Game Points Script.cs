using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePointsScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int currentScore;

    private int highScore;

    private string filePath;

    private int enemiesDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemiesDead = 0;
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        UFOScript.OnUFODied += UFOOnOnUFODied;
        Player.OnPlayerDied += PlayerOnOnPlayerDied;
        UFOScript.OnUFODied += UFOOnOnUFODied;
        currentScore = 0;
        filePath = Application.dataPath + "/HiScore.txt";
        highScore = int.Parse(File.ReadAllLines(filePath)[0]);
    }

    private void UFOOnOnUFODied(int points)
    {
<<<<<<< HEAD
        currentScore += points;
        string s = currentScore.ToString();
        while (s.Length < 4)
        {
            s = "0" + s;
        }

        text.text = "SCORE\n" + s;
    }
=======
        EnemyOnOnEnemyDied(points);
    }

>>>>>>> e451b9da3db0dff3b749a8de07991b73b8b09f22
    private void PlayerOnOnPlayerDied()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDead == 50)
        {
            UpdateHighScore();
            SceneManager.LoadScene("CreditsScene");
        }
    }
    void EnemyOnOnEnemyDied(int points)
    {
        ++enemiesDead;
        currentScore += points;
        string s = currentScore.ToString();
        while (s.Length < 4)
        {
            s = "0" + s;
        }

        text.text = "SCORE\n" + s;
    }

    void UpdateHighScore()
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

<<<<<<< HEAD
=======
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
    

>>>>>>> e451b9da3db0dff3b749a8de07991b73b8b09f22
}
