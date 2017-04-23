using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackTime : MonoBehaviour {


    public Text textTime;

    int m;
    int s;
    
	// Update is called once per frame
	void Update () {

        m = (int) GameManager.instance.TimeToColapse / 60;
        s = (int)GameManager.instance.TimeToColapse - (m * 60);

        textTime.text = (m < 10 ? "0" + m : "" + m) +":"+ (s < 10 ? "0" + s : "" + s);



    }
}
