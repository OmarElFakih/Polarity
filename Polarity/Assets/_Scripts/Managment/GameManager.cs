using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField]
    private AudioMixerSnapshot[] _snapshots = null;

    private int _index = 0;

    [SerializeField]
    private int _currentCatches = 0;

    [SerializeField]
    private int _catchesToUpgrade = 0;


    private void Awake()
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
        _snapshots[0].TransitionTo(.5f);
    }


    public void Score()
    {
        _currentCatches ++;

        if (_currentCatches >= _catchesToUpgrade)
        {
            _currentCatches = 0;

            if (_index < (_snapshots.Length -1))
                _index++;

            _snapshots[_index].TransitionTo(.5f);
        }
    }

    public void Hurt()
    {
        _currentCatches--;

        if (_currentCatches <= 0)
        {
            _currentCatches = _catchesToUpgrade/2;

            if (_index > 0)
                _index--;

            _snapshots[_index].TransitionTo(.5f);
        }
    }
}
