using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int numPlayersLife;
    public int score;
    public int highscore;
    public static float PLAYER_SPEED_MOVEMENT;
    public float PLAYER_JUMP_POWER;
    private float timer;
    private const float GAMETIME = 90;
//    public static float PROGRESS_SPEED;
    public Transform FloorBoard;

    private GameObject startScreen;
    private GameObject endScreen;
    private GameObject gameScreen;
    private bool startsc;
    private bool gamesc;
    private bool endsc;
    public TextMeshProUGUI mRoundTimeText;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighScore;
    public TextMeshProUGUI textlife;



    // Start is called before the first frame update
    void Start()
    {
        PLAYER_SPEED_MOVEMENT = 15;
        gameScreen = GameObject.Find("GameMode");
        startScreen = GameObject.Find("Start");
        endScreen = GameObject.Find("End");
        score = 0;
        
        highscore = PlayerPrefs.GetInt("highScore", 0);

        timer = GAMETIME;
        startScreen.SetActive(true);
        startsc = true;
        gamesc = false;
        endsc = false;
        gameScreen.SetActive(false);
        endScreen.SetActive(false);
        textHighScore.SetText(((int)highscore).ToString());


        // all of the objects but the opening screen are not active


    }

    // Update is called once per frame
    void Update()
    {
        // start with opening screen
        if (startsc)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // starting game
            {

                //startScreen.GetComponentInChildren<SpriteRenderer>().color = Color.black;
                startScreen.SetActive(false);
                gameScreen.SetActive(true);
                startsc = false;
                gamesc = true;
                textScore.SetText(((int)score).ToString());
            
                textlife.SetText(((int)numPlayersLife).ToString());
            }
        }
        if (gamesc)
        {
            CreateTexts();
            ObsticleManager.game = true;
            if (timer > 0 && numPlayersLife > 0)
            {
                UpdateRoundTime();
            }
            else
            {
                // if lost  go to lost screen
                gamesc = false;
                timer = GAMETIME;
                startScreen.SetActive(false);
                gameScreen.SetActive(false);
                endScreen.SetActive(true);
                if (score > highscore)
                {
                    PlayerPrefs.SetInt("highScore", score);
                    PlayerPrefs.Save();
                    //textHighScore.SetText(((int)highscore).ToString());
                }
                   
                endsc = true;
                ObsticleManager.game = false;
            }

        }
        if (endsc)
        {

            if (Input.GetKeyDown(KeyCode.Space)) // going to tutorial
            {
                SceneManager.LoadScene(0);
                endsc = false;
            }
        }


        // go to game and run game


        //go to end screen
        
    }
    public void UpScore()
    {
        score += 1;
        textScore.SetText(((int)score).ToString());
    }
    public void DecLife()
    {
        numPlayersLife -= 1;
        textlife.SetText(((int)numPlayersLife).ToString());
    }
    void CreateTexts()
    {

        mRoundTimeText.SetText(((int)timer).ToString());
    }
    private void UpdateRoundTime()
    {
        timer -= Time.deltaTime;
        if (timer <= 15)
        {
            mRoundTimeText.color = Color.red;
            mRoundTimeText.fontSize = 120;
        }
        mRoundTimeText.SetText(((int)timer).ToString());
    }
    public static float GetSpeed()
    {
        return PLAYER_SPEED_MOVEMENT;
    }
}