using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 pos;

    public void InstantiateRoutine()
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }

}
