using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gem : MonoBehaviour {

    public AutoRotation autoRot;
    public float IncrementSpeedRotationInDeath = 1;
    public bool InDeath = false;

    public ParticleSystem pSystem;


    public bool claimed = false;


	// Use this for initialization
	void Start () {
        autoRot = GetComponent<AutoRotation>();
	}

    private void Update()
    {
        if (InDeath)
        {
            autoRot.speed += Time.deltaTime * IncrementSpeedRotationInDeath;
            if(autoRot.speed > 10)
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
            if(!claimed) GameManager.instance.PlayerTouchGem();
            Death();
        }
    }



    void Death()
    {

        InDeath = true;

    }



}
