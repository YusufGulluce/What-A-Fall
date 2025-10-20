using UnityEngine;
using TMPro;

public class currentScore : MonoBehaviour, IDataPersistance
{

    private float oldScore = 0;
    private TextMeshProUGUI scoreText;
    private Transform camPos;
    private float startHeight = 0;

    private float newHighScore;
    private highestScore highScoreText;

    void Start()
    {
        highScoreText = GameObject.FindGameObjectWithTag("Highest Score").GetComponent<highestScore>();
        

        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        camPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        startHeight = camPos.position.y;
    }

    public void setHighScore(float score)
    {
        newHighScore = score;
    }

    void Update()
    {
        UpdateScore((int)(camPos.position.y - startHeight));

        
    }

    public void UpdateScore(float newScore)
    {
        if (newScore >= oldScore)
        {
            scoreText.text = newScore + "";
            oldScore = newScore;

            if(newScore > newHighScore)
            {
                highScoreText.updateScore(newScore);
            }
        }
    }

    public void LoadData(GameData data)
    {
        this.newHighScore = data.highScore;
    }

    public void SaveData(ref GameData data)
    {

    }
}
