using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarityBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Polarity _polarity = Polarity.Off;

   

    protected SpriteRenderer _renderer;

    protected virtual void Start()
    {
      
    }


    public Polarity GetPolarity()
    {
        return this._polarity;
    }

}
