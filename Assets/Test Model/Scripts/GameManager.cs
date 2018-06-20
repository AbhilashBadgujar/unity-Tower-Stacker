using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("UI")]
    [Space(5)]
    //[SerializeField] Text coinText;
    //[SerializeField] Text coinTextMenu;
    [SerializeField] Text scoreText;
    [SerializeField] Text HighscoreText;
    [SerializeField] GameObject[] canvas;

    [Header("Unity Objects")]
    [Space(5)]
    [SerializeField] AudioSource audio;
    

    [Header("Game Variavles")]
    [Space(5)]
    public int score, HighScore;
    public bool gameStart, gameOver;
    public static GameManager gm;
    


	// Use this for initialization
	void Start () {
        //coins = PlayerPrefs.GetInt("Coins");
        HighScore = PlayerPrefs.GetInt("highScore");
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        gm = this;   
        gameStart = false;
        gameOver = false;
        HighscoreText.text = "HighScore: " + HighScore;
        scoreText.text = "Score: " + score;
        //coinText.text = "Coina: " + coins;
        //coinTextMenu.text = "Coina: " + coins;
    }
	
	// Update is called once per frame
	public void StartGame () {
        audio.Play();
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
        canvas[2].SetActive(false);

        gameStart = true;   
    }

    private void Update()
    {
        if (gameOver) GameOver();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;

    }

    void GameOver()
    {
        gameStart = false;
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(true);
        //PlayerPrefs.SetInt("Coins", coins);
        if (score > HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt("highScore", HighScore);
            HighscoreText.text = "HighScore: " + HighScore;
        }
    }

    //public void UpdateText(){
    //    coins++;
    //    coinText.text = "Coina: " + coins;
    //}

    public void OnRetry()
    {
        SceneManager.LoadScene(0);
        audio.Play();
    }

    public void OnExit()
    {
        Application.Quit();
        audio.Play();
    }
}
