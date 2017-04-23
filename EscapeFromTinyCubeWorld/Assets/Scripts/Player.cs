using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;

    GameObject orbitCamera;

    Rigidbody rBody;
    public float speedMovement = 1f;
    public float speedRotate = 1f;



    public float CurrentHealth = 1f;
    public float MaxHealth = 1f;

    public bool isDeath = false;



    // Use this for initialization
    void Awake () {
        rBody = GetComponent<Rigidbody>();
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {

        if(CurrentHealth <= 0)
        {
            isDeath = true;
        }

        if (isDeath) return;

        if (GameManager.instance.state == GameManager.GameManagerState.CONTROL_PLAYER)
        {
            // Movement
            rBody.velocity = (Vector3.Normalize(transform.forward * InputController.instance.forward) +
                                (-1 * transform.forward * InputController.instance.backward) +
                                (-1 * transform.right * InputController.instance.left) +
                                (transform.right * InputController.instance.right))
                                * speedMovement 
                                
                                + rBody.velocity.y * Vector3.up;


            // Rotate camera
            Quaternion q = Quaternion.identity;
            q.eulerAngles = transform.rotation.eulerAngles +
                            (Vector3.up * InputController.instance.mouseYPos +
                            Vector3.down * InputController.instance.mouseYNeg)
                            * speedRotate;
            transform.rotation = q;
        }
    }


    public void TakeDamage(float damage)
    {
        //Debug.Log("taking damage ...");
        CurrentHealth -= damage;
    }

}
