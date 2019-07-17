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

    [SerializeField]
    private double _currentSpeed= 1d;

    public double playableSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _director = GetComponent<PlayableDirector>();
        _director.Play();
        playableSpeed = _director.playableGraph.GetRootPlayable(0).GetSpeed();
    }

    public void NewTimeline()
    {
        int index = Random.Range(0, _timeLines.Length);
        _director.Pause();
        _director.playableAsset = _timeLines[index];
        _director.time = 0;
        _director.Stop();
        _director.Evaluate();
        
        _director.Play();
        _currentSpeed += .2d;
        _director.playableGraph.GetRootPlayable(0).SetSpeed(_currentSpeed);
        playableSpeed = _director.playableGraph.GetRootPlayable(0).GetSpeed();
    }

    public void SpeedUp()
    {
        /*if (_director.playableGraph.IsValid())
        {
            _currentSpeed += .5d;
            _director.playableGraph.GetRootPlayable(0).SetSpeed(_currentSpeed);
        }*/
    }


}
