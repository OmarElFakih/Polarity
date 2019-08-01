using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PolarShift(Polarity pol);
    

    public static PolarShift OnPolarShift;
    

    public static EventManager instance;

    [SerializeField]
    private LayerMask inputLayer = default;

    
    private Polarity _currentPolarity = Polarity.Off;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Raycaster();
    }


    private void Raycaster()
    {
        Vector3 origin = Vector3.up * 100;

        #if UNITY_STANDALONE || UNITY_WEBGL ||UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            origin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        #elif UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                origin = Camera.main.ScreenToViewportPoint(Input.touches[0].position);
            }
        }
        #endif

        if (Physics2D.Raycast(origin, Vector2.zero, inputLayer) && (origin != Vector3.up * 100))
        {
            _currentPolarity = (_currentPolarity == Polarity.On) ? Polarity.Off : Polarity.On;
            OnPolarShift(_currentPolarity);
        }
    }

    


}
