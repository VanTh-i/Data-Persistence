using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Your High Score: " + ScoreManager.Instance.Highscore;
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "Your High Score: " + ScoreManager.Instance.Highscore;
    }
}
