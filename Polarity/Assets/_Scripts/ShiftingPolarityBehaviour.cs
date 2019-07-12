using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingPolarityBehaviour : PolarityBehaviour
{
    private static float _lerpT = 5f;

    private Color _targetColor = Color.white;

    private void OnEnable()
    {
        EventManager.OnPolarShift += ShiftPolarity;     
    }

    private void OnDisable()
    {
        EventManager.OnPolarShift -= ShiftPolarity;     
    }

    protected override void Start()
    {
        base.Start();
        _targetColor = _renderer.color;
    }

    private void Update()
    {
        _renderer.color = Color.Lerp(_renderer.color, _targetColor, _lerpT * Time.deltaTime);
    }


    public void ShiftPolarity(Polarity pol)
    {
        _polarity = pol;

        _targetColor = (_polarity == Polarity.On) ? _onColor : _offColor;
    }



}
