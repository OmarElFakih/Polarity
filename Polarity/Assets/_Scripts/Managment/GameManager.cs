using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public delegate void GameOver();
    public static GameOver OnGameOver;

    public delegate void Score();
    public static Score OnScore;

    public bool Kbuild;

    [SerializeField]
    private float _initialSpeed = 0;//initial speed of tokens

    [SerializeField]
    private float _maxSpeed = 0;//max speed of tokens

    [SerializeField]
    private float _lerpT = 0;//used to lerp the tokens speed

    [SerializeField]
    private GameObject _failBeat = null;

    [SerializeField]
    private Timer _gameTimer;

    [HideInInspector]
    public int score;

    [HideInInspector]
    public int _maxScore = 0;

    public GameObject[] gameScreens;

    private void OnEnable()
    {
        OnGameOver += GameOverRoutine;
        OnScore += ScoreRoutine;
    }

    private void OnDisable()
    {
        OnGameOver -= GameOverRoutine;
        OnScore -= ScoreRoutine;
    }

    private void Awake()//turns the gameobject into a singleton
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GameStart();
       
    }



    public void GameStart()
    {
        Token.fallSpeed = _initialSpeed;
        score = 0;
        Time.timeScale = 1;
        _maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

    public void ScoreRoutine()
    {
        Token.fallSpeed = Mathf.Lerp(Token.fallSpeed, _maxSpeed, _lerpT * Time.deltaTime);
        score += 1;
        if (Kbuild)
        {
            KAPI.instance.EnterStatistic("caught stars", 1);
        }

    }

    public void GameOverRoutine()
    {
        Debug.Log("GameOver");

        Instantiate(_failBeat, Vector3.zero, Quaternion.identity);
        SaveScore();
    }

    public void Pause()
    {
        Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
    }


    public void SaveScore()
    {
        if (score > _maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", score);
            gameScreens[1].SetActive(true);
            if (Kbuild)
            {
                KAPI.instance.EnterStatistic("score", score);
            }
        }
        else
        {
            gameScreens[0].SetActive(true);
        }

        gameScreens[2].SetActive(false);
    }

    

}

