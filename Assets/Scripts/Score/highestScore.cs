using UnityEngine;
using TMPro;

public class highestScore : MonoBehaviour, IDataPersistance
{
    private TextMeshProUGUI scoreText;
    private float highScore;

    void Start()
    {
        BuildComponents();
    }
    void BuildComponents()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public float getScore()
    {
        return highScore;
    }

    public void updateScore(float newScore)
    {
        scoreText.text = "High Score: " + newScore;
        highScore = newScore;

    }

    public void LoadData(GameData data)
    {
        this.highScore = data.highScore;
        BuildComponents();
        updateScore(highScore);

    }

    public void SaveData(ref GameData data)
    {
        data.highScore = this.highScore;
    }
}
