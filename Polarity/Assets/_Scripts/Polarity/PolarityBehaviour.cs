using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PolarityBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Polarity _polarity = Polarity.Off;



    protected Light2D _light;


    protected virtual void Start()
    {
      
    }


    public Polarity GetPolarity()
    {
        return this._polarity;
    }

}
