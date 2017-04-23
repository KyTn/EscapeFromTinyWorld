using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotateRubik : MonoBehaviour {

    public RubikControllerSplash rubik;


    public string[] axis = {
        "X_1_POS",
        "X_2_POS",
        "X_3_POS",
        "X_1_NEG",
        "X_2_NEG",
        "X_3_NEG",
        "Z_1_POS",
        "Z_2_POS",
        "Z_3_POS",
        "Z_1_NEG",
        "Z_2_NEG",
        "Z_3_NEG"};

    
	// Update is called once per frame
	void Update () {


        if (!rubik.IsRotating)
        {
            RubikControllerSplash.RotationAxis a = (RubikControllerSplash.RotationAxis)System.Enum.Parse(typeof(RubikControllerSplash.RotationAxis), axis[Random.Range(0, axis.Length)]);
            rubik.RotateToAxis(a);
        }


    }
}
