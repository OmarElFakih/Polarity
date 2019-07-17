using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject[] prefabs;
    public Vector3 pos;

    public void InstantiateRoutine(int index)
    {
        Instantiate(prefabs[index], pos, Quaternion.identity);
    }

}
