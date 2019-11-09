using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarWellTimer : Timer
{
    private void OnEnable()
    {
        GameManager.OnGameOver += Deactivate;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= Deactivate;
    }


    public void Deactivate()
    {
        canExecute = false;
    }
}
