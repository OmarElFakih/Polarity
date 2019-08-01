using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField]
    private float _initialSpeed = 0;//initial speed of tokens

    [SerializeField]
    private float _maxSpeed = 0;//max speed of tokens

    [SerializeField]
    private float _lerpT = 0;//used to lerp the tokens` speed

    [HideInInspector]
    public int score;

    private void Awake()//turns the gameobject into a singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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
    }


    public void Score()
    {
        Token.fallSpeed = Mathf.Lerp(Token.fallSpeed, _maxSpeed, _lerpT * Time.deltaTime);
        score += 1;

    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}
