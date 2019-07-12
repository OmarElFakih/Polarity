using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeLineExecuter : MonoBehaviour
{
    public UnityEvent timeLineEvent;



    private void OnEnable()
    {
        StartCoroutine(EnabledRoutine());
        if (timeLineEvent != null)
        { timeLineEvent.Invoke(); }
    }

    private void Start()
    {
        StartCoroutine(EnabledRoutine());
    }

    private IEnumerator EnabledRoutine()
    {
        yield return new WaitForEndOfFrame();
        this.enabled = true;
    }
}
