using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class ShiftingPolarityBehaviour : PolarityBehaviour
{
    private static float _lerpT = 3f;

    [SerializeField]
    protected Color _onColor = Color.white;

    [SerializeField]
    protected Color _offColor = Color.white;

    private Color _targetColor = Color.white;

    private bool _isShifting = false;

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
        _light = GetComponent<Light2D>();

        if (_light != null)
        {
            _light.color = (_polarity == Polarity.On) ? _onColor : _offColor;
        }

        else Debug.Log("renderer is null");

        _targetColor = _light.color;
    }

  /*  private void Update()
    {
        _light.color = Color.Lerp(_light.color, _targetColor, _lerpT * Time.deltaTime);
    }*/


    public void ShiftPolarity(Polarity pol)
    {
        _polarity = pol;

        _targetColor = (_polarity == Polarity.On) ? _onColor : _offColor;

        if (!_isShifting)
        {
            StartCoroutine(ShiftRoutine());
        }
    }



    private IEnumerator ShiftRoutine()
    {
        _isShifting = true;

        while (_light.color != _targetColor)
        {
            _light.color = Color.Lerp(_light.color, _targetColor, _lerpT * Time.deltaTime);
            yield return null;
        }

        _isShifting = false;
    }



}
