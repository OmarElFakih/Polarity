using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : PolarityBehaviour
{
    public static float fallSpeed = 1f;


    [SerializeField]
    private GameObject _beat = null;


    private void OnEnable()
    {
        GameManager.OnGameOver += GameOverRoutine;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= GameOverRoutine;
    }

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PolarityBehaviour contact = other.GetComponent<PolarityBehaviour>();

        if (contact.GetPolarity() == this._polarity)
        {
            //score
            GameManager.OnScore();
            Instantiate(_beat, transform.position, Quaternion.identity);

        }
        else
        {
            //hurt
            GameManager.OnGameOver();
         
        }

        Destroy(this.gameObject, 1f);
    }

    public void GameOverRoutine()
    {
        Destroy(this.gameObject);
    }


}
