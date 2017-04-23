using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackHealth : MonoBehaviour {



    public Slider slider;
    

    // Update is called once per frame
    void Update()
    {


        slider.value = Player.instance.CurrentHealth / Player.instance.MaxHealth;


    }
}
