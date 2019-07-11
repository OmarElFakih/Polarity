using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarityBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Polarity _polarity = Polarity.Off;

    [SerializeField]
    protected Color _onColor = Color.white;

    [SerializeField]
    protected Color _offColor = Color.white;

    protected SpriteRenderer _renderer;

    protected virtual void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        if (_renderer != null)
        {
            _renderer.color = (_polarity == Polarity.On) ? _onColor : _offColor;
        }

        else Debug.Log("renderer is null");
    }


    public Polarity GetPolarity()
    {
        return this._polarity;
    }

}
