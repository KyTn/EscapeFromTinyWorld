using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    public Material good, bad;

    public MeshRenderer meshR;

    private void Awake()
    {
        meshR = AxisSelectorManager.instance.CubeSelector.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            meshR.material = bad;
            AxisSelectorManager.instance.playerOnCube = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            meshR.material = good;
            AxisSelectorManager.instance.playerOnCube = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            //meshR.material = good;
            AxisSelectorManager.instance.playerOnCube = true;
        }
    }
}
