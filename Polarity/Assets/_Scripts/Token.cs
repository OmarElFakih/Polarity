using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : PolarityBehaviour
{
    [SerializeField]
    private GameObject _beat = null;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PolarityBehaviour contact = other.GetComponent<PolarityBehaviour>();

        if (contact.GetPolarity() == this._polarity)
        {
            //score
            Instantiate(_beat, Vector3.zero, Quaternion.identity);
            Debug.Log("Score");
        }
        else
        {
            //hurt
            Debug.Log("Hurt");
        }
    }

}
