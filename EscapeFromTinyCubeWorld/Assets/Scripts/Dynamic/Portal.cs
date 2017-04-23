using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Portal : MonoBehaviour {

    public AutoRotation autoRot;
    public float IncrementSpeedRotationInDeath = 1;
    public bool InDeath = false;

    public ParticleSystem pSystem;

    // Use this for initialization
    void Start()
    {
        autoRot = GetComponent<AutoRotation>();
    }

    private void Update()
    {
        if (InDeath)
        {
            autoRot.speed += Time.deltaTime * IncrementSpeedRotationInDeath;
            if (autoRot.speed > 10)
            {
                transform.DOScale(Vector3.up * 1, 1.9f).OnComplete(() => { Destroy(gameObject); });
            }
        }
    }


    private void OnTriggerEnter(Collider collision)
    {

        //Debug.Log("collision gem "+collision.gameObject.name + " tag "+ collision.gameObject.tag );

        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("in");
            GameManager.instance.ChangeStateTo(GameManager.GameManagerState.WIN);
            Death();
        }
    }



    void Death()
    {

        InDeath = true;

    }
}
