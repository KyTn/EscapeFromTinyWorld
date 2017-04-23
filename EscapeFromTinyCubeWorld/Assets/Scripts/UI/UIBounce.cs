using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBounce : MonoBehaviour {

    public RectTransform target;


    float scale = 1;
    public float velocityScale = 1;
    bool incrementing = false;
    public Vector2 maxmin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (incrementing)
        {
            scale += Time.deltaTime * velocityScale;
        }
        else
        {
            scale -= Time.deltaTime * velocityScale;
        }

        if (scale >= maxmin.y) incrementing = false;
        else if (scale <= maxmin.x) incrementing = true;

        target.localScale = Vector3.one * scale;




	}
}
