using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreReader : MonoBehaviour
{
    private int maxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        GetComponent<TextMeshProUGUI>().text = "" + maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
