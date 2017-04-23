using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAtContact : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Player.instance.TakeDamage(2);
        }
    }
}
