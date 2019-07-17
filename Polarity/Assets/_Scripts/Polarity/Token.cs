using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : PolarityBehaviour
{
    public static float fallSpeed;


    [SerializeField]
    private GameObject _beat = null;

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PolarityBehaviour contact = other.GetComponent<PolarityBehaviour>();

        if (contact.GetPolarity() == this._polarity)
        {
            //score
            GameManager.instance.Score();
            Instantiate(_beat, Vector3.zero, Quaternion.identity);
            Debug.Log("Score");
        }
        else
        {
            //hurt
            GameManager.instance.Hurt();
            Debug.Log("Hurt");
        }

        Destroy(this.gameObject);
    }

}
