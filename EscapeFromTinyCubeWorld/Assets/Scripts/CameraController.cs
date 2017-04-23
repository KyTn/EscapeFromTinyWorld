using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour {

    public static CameraController instance;



    public GameObject MCamera;

    public List<GameObject> Control_Rubik_List;
    public GameObject Control_Player;

    public float duration;


    public void Awake()
    {
        instance = this;
    }

    public void Goto_Control_Rubik()
    {
        AxisSelectorManager.AxisSelectorType axisSelectorType = AxisSelectorManager.AxisSelectorType.AB;
        GameObject chosen = Control_Rubik_List[0];
        float distance = float.MaxValue;

        for(int i = 0; i < Control_Rubik_List.Count; i++)
        {
            GameObject g = Control_Rubik_List[i];
            

            if (distance > (MCamera.transform.position - g.transform.position).magnitude)
            {
                if (i == 0) axisSelectorType = AxisSelectorManager.AxisSelectorType.AB;
                if (i == 1) axisSelectorType = AxisSelectorManager.AxisSelectorType.BC;
                if (i == 2) axisSelectorType = AxisSelectorManager.AxisSelectorType.CD;
                if (i == 3) axisSelectorType = AxisSelectorManager.AxisSelectorType.DA;
                distance = (MCamera.transform.position - g.transform.position).magnitude;
                chosen = g;
            }
        }

        MCamera.transform.parent = chosen.transform;

        MCamera.transform.DOLocalMove(Vector3.zero, duration);
        MCamera.transform.DOLocalRotate(Vector3.zero, duration);

        AxisSelectorManager.instance.SetSelectorTo(axisSelectorType);

    }

    public void Goto_Control_Player()
    {
        AxisSelectorManager.instance.CubeSelector.SetActive(false);
        AxisSelectorManager.instance.ActualSelector.SetActive(false);


        MCamera.transform.parent = Control_Player.transform;

        MCamera.transform.DOLocalMove(Vector3.zero, duration);
        MCamera.transform.DOLocalRotate(Vector3.zero, duration);
    }

    public void Goto_Lose()
    {
        AxisSelectorManager.AxisSelectorType axisSelectorType = AxisSelectorManager.AxisSelectorType.AB;
        GameObject chosen = Control_Rubik_List[0];
        float distance = float.MaxValue;

        for (int i = 0; i < Control_Rubik_List.Count; i++)
        {
            GameObject g = Control_Rubik_List[i];


            if (distance > (MCamera.transform.position - g.transform.position).magnitude)
            {
                if (i == 0) axisSelectorType = AxisSelectorManager.AxisSelectorType.AB;
                if (i == 1) axisSelectorType = AxisSelectorManager.AxisSelectorType.BC;
                if (i == 2) axisSelectorType = AxisSelectorManager.AxisSelectorType.CD;
                if (i == 3) axisSelectorType = AxisSelectorManager.AxisSelectorType.DA;
                distance = (MCamera.transform.position - g.transform.position).magnitude;
                chosen = g;
            }
        }

        MCamera.transform.parent = chosen.transform;

        MCamera.transform.DOLocalMove(Vector3.zero, duration);
        MCamera.transform.DOLocalRotate(Vector3.zero, duration);

        AxisSelectorManager.instance.SetSelectorTo(axisSelectorType);


        AxisSelectorManager.instance.CubeSelector.SetActive(false);
        AxisSelectorManager.instance.ActualSelector.SetActive(false);

    }
}
