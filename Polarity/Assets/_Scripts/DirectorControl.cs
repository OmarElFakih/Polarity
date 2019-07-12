using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DirectorControl : MonoBehaviour
{
    [SerializeField]
    private TimelineAsset[] _timeLines = null;

    private PlayableDirector _director = null;


    // Start is called before the first frame update
    void Start()
    {
        _director = GetComponent<PlayableDirector>();
    }

    public void NewWave()
    {
        int index = Random.Range(0, _timeLines.Length);
        _director.playableAsset = _timeLines[index];
        _director.Play();
    }

}
