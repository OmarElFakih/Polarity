using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimer;

  
    [SerializeField]
    private float _intervals = 0f;

    [SerializeField]
    private float _targetInterval = 0f;

    private float _nextTimer = 0f;

    [SerializeField]
    private float _lerpT;

    public bool _canExecute = true;


    private void Awake()
    {
        _nextTimer = Time.time + _intervals;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextTimer)
        {
            OnTimer.Invoke();
            _intervals = Mathf.Lerp(_intervals, _targetInterval, _lerpT * Time.deltaTime);
            _nextTimer = Time.time + _intervals; 
        }
    }


}
