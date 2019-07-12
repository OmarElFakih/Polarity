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

    private double _currentSpeed= 1d;

    // Start is called before the first frame update
    void Start()
    {
        _director = GetComponent<PlayableDirector>();
        _director.Play();
    }

    public void NewTimeline()
    {
        int index = Random.Range(0, _timeLines.Length);
        _director.Pause();
        _director.playableAsset = _timeLines[index];
        _director.Play();
    }

    public void SpeedUp()
    {
        if (_director.playableGraph.IsValid())
        {
            _currentSpeed += .5d;
            _director.playableGraph.GetRootPlayable(0).SetSpeed(_currentSpeed);
        }
    }


}
