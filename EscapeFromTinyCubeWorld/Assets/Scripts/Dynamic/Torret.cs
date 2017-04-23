using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour {



    public GameObject target;

    public LineRenderer lineR;

    // Use this for initialization
    void Start () {
        lineR.SetPosition(0, transform.position);
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;


       if( Physics.Raycast(transform.position, (transform.position - target.transform.position).normalized * 10, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Player.instance.TakeDamage(0.4f);
            }


            lineR.SetPosition(0, transform.position);
            lineR.SetPosition(1, hit.point);

        }else
        {
            lineR.SetPosition(0, transform.position);
            lineR.SetPosition(1, (transform.position - target.transform.position).normalized * 10);
        }

    }



    

}
