using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameCanvas : CanvasManager
{


    [SerializeField]
    private TextMeshProUGUI[] _scoreText = null;

    private void OnEnable()
    {
        GameManager.OnScore += UpdateScore;
    
    }

    private void OnDisable()
    {
        GameManager.OnScore -= UpdateScore;
       
    }

    public void PauseRequest()
    {
        GameManager.instance.Pause();
    }

    public void UpdateScore()
    {
        IEnumerator setText()
        {
            yield return new WaitForEndOfFrame();
            foreach (TextMeshProUGUI t in _scoreText)
            {
                t.text = GameManager.instance.score + "";
            }
        }

        StartCoroutine(setText());
    }

   
    
}
