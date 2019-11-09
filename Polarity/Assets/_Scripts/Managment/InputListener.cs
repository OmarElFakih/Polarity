using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public delegate void PolarShift(Polarity pol);
    

    public static PolarShift OnPolarShift;
    

    public static InputListener instance;

    [SerializeField]
    private LayerMask inputLayer = default;

    public Animator animator;

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
        

        #if UNITY_STANDALONE || UNITY_WEBGL ||UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 origin = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (Physics2D.Raycast(origin, Vector2.zero, inputLayer))
            {
                _currentPolarity = (_currentPolarity == Polarity.On) ? Polarity.Off : Polarity.On;
                OnPolarShift(_currentPolarity);
                animator.SetTrigger("Shift");
            }
        }
        #elif UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Vector3 origin = Camera.main.ScreenToViewportPoint(Input.touches[0].position);


                if (Physics2D.Raycast(origin, Vector2.zero, inputLayer))
                {
                    _currentPolarity = (_currentPolarity == Polarity.On) ? Polarity.Off : Polarity.On;
                    OnPolarShift(_currentPolarity);
                   animator.SetTrigger("Shift");
                }
            }

        }
        #endif

       /* if (Physics2D.Raycast(origin, Vector2.zero, inputLayer))
        {
            _currentPolarity = (_currentPolarity == Polarity.On) ? Polarity.Off : Polarity.On;
            OnPolarShift(_currentPolarity);
            animator.SetTrigger("Shift");
        }*/
    }

    


}
