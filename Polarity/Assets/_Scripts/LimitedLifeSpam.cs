﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLifeSpam : MonoBehaviour
{
    [SerializeField]
    private float lifespam = 0f;


    void Start()
    {
        Destroy(this.gameObject, lifespam);
    }

  
}
