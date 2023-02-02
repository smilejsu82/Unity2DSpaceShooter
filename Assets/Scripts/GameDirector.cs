using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text textScore;
    private int score;
    private int life = 2;
    public PlayerController player;

    public GameObject[] lifes;

    private void Start()
    {
        this.player.onDie = () => {
            this.life -= 1;

            for (int i = 0; i < lifes.Length; i++) 
                this.lifes[i].gameObject.SetActive(false);
            for (int i = 0; i < life; i++)
                this.lifes[i].gameObject.SetActive(true);

            if (this.life <= 0) {
                Debug.Log("Game Over");
                //¾ÀÀüÈ¯ 
                SceneManager.LoadScene("GameOverScene");
            }
        };
    }

    public void UpdateScore(int addScore) {
        this.score += addScore;
        this.textScore.text = string.Format("{0}", this.score);
    }
}
