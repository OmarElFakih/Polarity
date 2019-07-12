using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuterActivator : MonoBehaviour
{
    private TimeLineExecuter _executer = null;

    private void OnEnable()
    {
        _executer = GetComponent<TimeLineExecuter>();
        _executer.enabled = true;
    }
}
