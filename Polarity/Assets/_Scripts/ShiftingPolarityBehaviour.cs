using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingPolarityBehaviour : PolarityBehaviour
{
    [SerializeField]
    float lerp_t = 0f;

    private Color _targetColor = Color.white;

    protected override void Start()
    {
        base.Start();
        _targetColor = _renderer.color;
    }

    private void Update()
    {
        _renderer.color = Color.Lerp(_renderer.color, _targetColor, lerp_t * Time.deltaTime);
    }


    public void ShiftPolarity(Polarity pol)
    {
        _polarity = pol;

        _targetColor = (_polarity == Polarity.On) ? _onColor : _offColor;
    }



}
