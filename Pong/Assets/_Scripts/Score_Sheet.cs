using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Sheet : MonoBehaviour {
    public static Score_Sheet instance;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    float playerScore = 0f;
    float enemyScore = 0f;

    public Text playerScore_UI;
    public Text enemyScore_UI;
    public GameObject endPanel_UI;
    public Text winner_UI;
    public Text playerOneScore_UI;
    public Text playerTwoScore_UI;

    public void PlayerScored()
    {
        playerScore++;
        playerScore_UI.text = playerScore.ToString();
    }
    public void EnemyScored()
    {
        enemyScore++;
        enemyScore_UI.text = enemyScore.ToString();
    }

    private void Update()
    {
        if(playerScore >= 3 && !endPanel_UI.activeSelf)
        {
            GameOver("Player One");
        }
        else if(enemyScore >= 3 && !endPanel_UI.activeSelf)
        {
            GameOver("Player Two");
        }
    }

    public void GameOver(string winner)
    {
        if (endPanel_UI.activeSelf)
        {
            Time.timeScale = 1f;
            endPanel_UI.SetActive(false);
        }
        else if(!endPanel_UI.activeSelf)
        {
            Time.timeScale = 0f;
            playerOneScore_UI.text = playerScore.ToString();
            playerTwoScore_UI.text = enemyScore.ToString();
            winner_UI.text = winner + " wins!";
            endPanel_UI.SetActive(true);
        }
    }
}
