using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class AxisSelectorManager : MonoBehaviour {

    public enum AxisSelectorType { AB,BC,CD,DA};


    public static AxisSelectorManager instance;

    public AxisSelectorType state;

    public List<GameObject> A, B, C, D;

    public List<GameObject> Left, Right;

    public GameObject ActualSelector;

    public int ActualSelectorIndex = 0;


    public GameObject CubeSelector;

    public float ScaleLarge = 3.5f;
    public float ScaleShort = 1.1f;
    public float CubeSelecterMovementSeconds = 0.4f, CubeSelecterRescaleSeconds = 0.4f;

    public bool playerOnCube = false;


    private void Awake()
    {
        instance = this;
        ActualSelectorIndex = 0;
        foreach (GameObject g in A)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in B)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in C)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in D)
        {
            g.SetActive(false);
        }

        if (ActualSelector != null) ActualSelector.SetActive(false);
        Left = B;
        Right = C;
        ActualSelector = Left[0];
        //ActualSelector.SetActive(true);
        CubeSelector.SetActive(false);
        PlaceCubeSelector();
    }




    void Start () {
        
    }

    

    public void SetSelectorTo(AxisSelectorType sel)
    {
        //Debug.Log("Selecting " + sel);
        state = sel;
        switch (state)
        {
            case AxisSelectorType.AB:
                
                Left = A;
                Right = B;
                UpdateSelector();
                break;
            case AxisSelectorType.BC:
                Left = B;
                Right = C;
                UpdateSelector();
                break;
            case AxisSelectorType.CD:
                Left = C;
                Right = D;
                UpdateSelector();
                break;
            case AxisSelectorType.DA:
                Left = D;
                Right = A;
                UpdateSelector();
                break;
        }
    }



    void UpdateSelector()
    {
        ActualSelectorIndex = 0;
        foreach (GameObject g in A)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in B)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in C)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in D)
        {
            g.SetActive(false);
        }

        if(ActualSelector != null)ActualSelector.SetActive(false);
        ActualSelector = Left[0];
        ActualSelector.SetActive(true);
        PlaceCubeSelector();
    }







    
    public void MoveToLeft()
    {

        ActualSelector.SetActive(false);

        if (state == AxisSelectorType.AB)
        {

            switch (ActualSelectorIndex)
            {
                case 0:
                    ActualSelector = Right[2];
                    break;
                case 1:
                    ActualSelector = Left[0];
                    break;
                case 2:
                    ActualSelector = Left[1];
                    break;
                case 3:
                    ActualSelector = Left[2];
                    break;
                case 4:
                    ActualSelector = Right[0];
                    break;
                case 5:
                    ActualSelector = Right[1];
                    break;
            }
        }
        else if(state == AxisSelectorType.BC)
        {

            switch (ActualSelectorIndex)
            {
                case 0:
                    ActualSelector = Right[2];
                    break;
                case 1:
                    ActualSelector = Left[0];
                    break;
                case 2:
                    ActualSelector = Left[1];
                    break;
                case 3:
                    ActualSelector = Left[2];
                    break;
                case 4:
                    ActualSelector = Right[0];
                    break;
                case 5:
                    ActualSelector = Right[1];
                    break;
            }
        }
        else if (state == AxisSelectorType.CD)
        {

            switch (ActualSelectorIndex)
            {
                case 0:
                    ActualSelector = Right[2];
                    break;
                case 1:
                    ActualSelector = Left[0];
                    break;
                case 2:
                    ActualSelector = Left[1];
                    break;
                case 3:
                    ActualSelector = Left[2];
                    break;
                case 4:
                    ActualSelector = Right[0];
                    break;
                case 5:
                    ActualSelector = Right[1];
                    break;
            }
        }
        else if (state == AxisSelectorType.DA)
        {

            switch (ActualSelectorIndex)
            {
                case 0:
                    ActualSelector = Right[2];
                    break;
                case 1:
                    ActualSelector = Left[0];
                    break;
                case 2:
                    ActualSelector = Left[1];
                    break;
                case 3:
                    ActualSelector = Left[2];
                    break;
                case 4:
                    ActualSelector = Right[0];
                    break;
                case 5:
                    ActualSelector = Right[1];
                    break;
            }
        }


        ActualSelectorIndex--;

        ActualSelectorIndex = ActualSelectorIndex < 0 ? 5 : ActualSelectorIndex;
        ActualSelectorIndex = ActualSelectorIndex > 5 ? 0 : ActualSelectorIndex;
        ActualSelectorIndex %= 6;

        ActualSelector.SetActive(true);
        PlaceCubeSelector();
    }


    public void MoveToRight()
    {

        ActualSelector.SetActive(false);

        switch (ActualSelectorIndex)
        {
            case 0:
                ActualSelector = Left[1]; 
                break;
            case 1:
                ActualSelector = Left[2];
                break;
            case 2:
                ActualSelector = Right[0];
                break;
            case 3:
                ActualSelector = Right[1];
                break;
            case 4:
                ActualSelector = Right[2];
                break;
            case 5:
                ActualSelector = Left[0];
                break;
        }

        ActualSelectorIndex++;
        ActualSelectorIndex = ActualSelectorIndex < 0 ? 5 : ActualSelectorIndex;
        ActualSelectorIndex = ActualSelectorIndex > 5 ? 0 : ActualSelectorIndex;
        ActualSelectorIndex %= 6;

        ActualSelector.SetActive(true);
        PlaceCubeSelector();
    }

    void PlaceCubeSelector()
    {

        CubeSelector.SetActive(true);

        if (state == AxisSelectorType.AB)
        {
            if (ActualSelectorIndex == 3)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 0), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 4)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 5)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 2), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 2)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(0, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 1)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 0)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(2, 1, 1), CubeSelecterMovementSeconds);
            }
        }
        else if (state == AxisSelectorType.BC)
        {
            if (ActualSelectorIndex == 0)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 0), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 1)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 2)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 2), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 3)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(0, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 4)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 5)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(2, 1, 1), CubeSelecterMovementSeconds);
            }
        }
        else if (state == AxisSelectorType.CD)
        {
            if (ActualSelectorIndex == 5)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 0), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 4)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 3)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 2), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 0)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(0, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 1)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 2)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(2, 1, 1), CubeSelecterMovementSeconds);
            }
        }
        else if (state == AxisSelectorType.DA)
        {
            if (ActualSelectorIndex == 2)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 0), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 1)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 0)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 2), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 5)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(0, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 4)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 3)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(2, 1, 1), CubeSelecterMovementSeconds);
            }
        }



        /*
        


            if (ActualSelectorIndex == 0)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 0), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 1)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 2)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleLarge, ScaleLarge, ScaleShort), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 2), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 3)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(0, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 4)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(1, 1, 1), CubeSelecterMovementSeconds);
            }
            if (ActualSelectorIndex == 5)
            {
                CubeSelector.transform.DOScale(new Vector3(ScaleShort, ScaleLarge, ScaleLarge), CubeSelecterRescaleSeconds);
                CubeSelector.transform.DOMove(new Vector3(2, 1, 1), CubeSelecterMovementSeconds);
            }*/
        
    }
}
