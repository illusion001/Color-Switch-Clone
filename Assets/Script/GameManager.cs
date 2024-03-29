using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int score;
    public Text Scoreboard;
    public GameObject gameStartUI;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        gameStartUI.SetActive(false);
        Scoreboard.gameObject.SetActive(true);
    }

    public void Restart()
    {
        
        SceneManager.LoadScene("main");
        score = 0;
    }

    public void scoreUp()
    {
        score = score+1;
        Scoreboard.text = score.ToString();
    }
}
