using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager instance;


    #region State

    public enum GameManagerState { MENU = 0, CONTROL_PLAYER = 1, CONTROL_RUBIK = 2, STOP = 3, LOSE = 4, WIN = 5};

   

    // 0 menu, 1 player, 2 planning, 3 stop
    public GameManagerState state = GameManagerState.CONTROL_PLAYER;

    public void ChangeStateTo(GameManagerState newState)
    {
        state = newState;

        switch (state)
        {
            case GameManagerState.MENU: break;
            case GameManagerState.CONTROL_PLAYER: CameraController.instance.Goto_Control_Player(); break;
            case GameManagerState.CONTROL_RUBIK: CameraController.instance.Goto_Control_Rubik(); break;
            case GameManagerState.STOP: break;
            case GameManagerState.LOSE:
                CameraController.instance.Goto_Lose();
                break;
            case GameManagerState.WIN:
                CameraController.instance.Goto_Lose();
                break;
        }
    }


    #endregion

    bool LButtonPressed = false;
    bool RButtonPressed = false;
    bool RCentralButtonPressed = false;





    // Use this for initialization
    void Awake () {
        instance = this;

        ChangeStateTo(GameManagerState.CONTROL_PLAYER);
        CameraController.instance.Goto_Control_Player();
        Faces = new List<GameObject>();
    }

    private void Start()
    {
        GenerateDynamicElements();
    }


    // Update is called once per frame
    void Update () {
        if (state != GameManagerState.WIN && Player.instance.isDeath)
        {
            ChangeStateTo(GameManagerState.LOSE);
        }

        switch (state)
        {
            case GameManagerState.MENU:

                TimeToColapse -= Time.deltaTime;

                break;
            case GameManagerState.CONTROL_PLAYER:

                TimeToColapse -= Time.deltaTime;

                if (InputController.instance.RightCentralButton > 0 && !RCentralButtonPressed)
                {
                    RCentralButtonPressed = true;

                    CameraController.instance.Goto_Control_Rubik();
                    ChangeStateTo(GameManagerState.CONTROL_RUBIK);

                }
                else if (!(InputController.instance.RightCentralButton > 0))
                {
                    RCentralButtonPressed = false;
                }
                break;

            case GameManagerState.CONTROL_RUBIK:

                TimeToColapse -= Time.deltaTime;

                if (InputController.instance.RightCentralButton > 0 && !RCentralButtonPressed)
                {
                    RCentralButtonPressed = true;

                    CameraController.instance.Goto_Control_Player();
                    ChangeStateTo(GameManagerState.CONTROL_PLAYER);

                }
                else if (!(InputController.instance.RightCentralButton > 0))
                {
                    RCentralButtonPressed = false;
                }



                if (InputController.instance.LButton > 0 && !LButtonPressed)
                {
                    LButtonPressed = true;
                    AxisSelectorManager.instance.MoveToLeft();
                }
                else if (!(InputController.instance.LButton > 0))
                {
                    LButtonPressed = false;
                }

                if (InputController.instance.RButton > 0 && !RButtonPressed)
                {
                    RButtonPressed = true;
                    AxisSelectorManager.instance.MoveToRight();
                }
                else if (!(InputController.instance.RButton > 0))
                {
                    RButtonPressed = false;
                }

                if (InputController.instance.AButton > 0)
                {
                    RubikController.instance.RotateToAxis(RotationAxisFromActualSelector());
                }

                if (InputController.instance.BButton > 0)
                {
                    RubikController.instance.RotateToAxis(RotationInverseAxisFromActualSelector());
                }

                
                break;


            case GameManagerState.STOP: break;
        }


        

        if(TimeToColapse <= 0)
        {
            Colapse();
        }



    }


    RubikController.RotationAxis RotationAxisFromActualSelector()
    {
        return AxisSelectorManager.instance.ActualSelector.GetComponent<AxisSelector>().AXIS;
    }


    RubikController.RotationAxis RotationInverseAxisFromActualSelector()
    {
        return AxisSelectorManager.instance.ActualSelector.GetComponent<AxisSelector>().INVERSE_AXIS;
    }

    #region INSTANTIATE DYNAMIC GO 

    public GameObject GemPrefab;
    public GameObject PortalPrefab;
    public GameObject TorretPrefab;

    public bool IsPortalOpen = false;



    public int numGemsNeeded = 7;
    public int coinsInGame = 10;
    public int enemies = 10;
    public int torrets = 10;

    public List<GameObject> Faces;

    public void AddFace(GameObject face)
    {
        Faces.Add(face);
    }


    void GenerateDynamicElements()
    {

        // Instantiate Gems 

        int gemsInstantiated = 0;

        List<Face> faceWithGems = new List<Face>();

        foreach (GameObject go in Faces)
        {
            Face f = go.GetComponent<Face>();
            if (f.Gems.Count > 0)
            {
                faceWithGems.Add(f);
            }
        }

        while (gemsInstantiated < numGemsNeeded)
        {
            Face f = faceWithGems[UnityEngine.Random.Range(0, faceWithGems.Count)];


            // podemos instanciar una gema aqui

            GameObject g = Instantiate(GemPrefab) as GameObject;
            g.transform.parent = f.transform;
            g.transform.localPosition = f.Gems[UnityEngine.Random.Range(0, f.Gems.Count)];

            g.transform.localRotation = Quaternion.identity;
            gemsInstantiated++;


        }

        // Instantiate Torrets

        int torretsInstantiated = 0;

        List<Face> faceWithTorrets = new List<Face>();

        foreach (GameObject go in Faces)
        {
            Face f = go.GetComponent<Face>();
            if (f.Torrets.Count > 0)
            {
                faceWithTorrets.Add(f);
            }
        }

        while (torretsInstantiated < torrets)
        {
            Face f = faceWithTorrets[UnityEngine.Random.Range(0, faceWithTorrets.Count)];


            // podemos instanciar una gema aqui

            GameObject g = Instantiate(TorretPrefab) as GameObject;
            g.transform.parent = f.transform;
            g.transform.localPosition = f.Torrets[UnityEngine.Random.Range(0, f.Torrets.Count)];

            g.transform.localRotation = Quaternion.identity;
            torretsInstantiated++;


        }



    }

    #endregion



    #region DYNAMIC BEHAVIOURS

    public float TimeToColapse = 300;

    private void Colapse()
    {
        ChangeStateTo(GameManagerState.LOSE);
    }

    public int GemsTouched = 0;


    public void PlayerTouchGem()
    {
        GemsTouched++;

        if(GemsTouched >= numGemsNeeded)
        {
            CreatePortal();
        }
    }

    public void CreatePortal()
    {
        List<Face> faceWithGems = new List<Face>();

        foreach (GameObject go in Faces)
        {
            Face fa = go.GetComponent<Face>();
            if (fa.Gems.Count > 0)
            {
                faceWithGems.Add(fa);
            }
        }

        Face f = faceWithGems[UnityEngine.Random.Range(0, faceWithGems.Count)];


        // podemos instanciar una gema aqui

        GameObject g = Instantiate(PortalPrefab) as GameObject;
        g.transform.parent = f.transform;
        g.transform.localPosition = f.Gems[UnityEngine.Random.Range(0, f.Gems.Count)];

        g.transform.localRotation = Quaternion.identity;


        IsPortalOpen = true;


    }




    #endregion

}
