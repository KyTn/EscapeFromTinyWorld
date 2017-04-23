using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackGems : MonoBehaviour {



    public Text textGems;

    // Update is called once per frame
    void Update()
    {
        textGems.text = GameManager.instance.GemsTouched + " / " + GameManager.instance.numGemsNeeded;
    }
}
