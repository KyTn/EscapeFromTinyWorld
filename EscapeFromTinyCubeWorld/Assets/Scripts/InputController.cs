using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public static InputController instance;


    Director director;

    public float forwardRaw;
    public float leftRaw;

    public float forward;
    public float backward;
    public float left;
    public float right;

    public float AButton;
    public float BButton;
    public float XButton;
    public float YButton;

    public float RButton;
    public float LButton;

    public float RLTrigger;

    public float mouseXRaw;
    public float mouseYRaw;
    public float mouseXPos;
    public float mouseXNeg;
    public float mouseYPos;
    public float mouseYNeg;

    public float startButton;
    public float backButton;

    public float upArrowButton;
    public float downArrowButton;
    public float leftArrowButton;
    public float rightArrowButton;


    public float LeftCentralButton;
    public float RightCentralButton;


    void Awake()
    {
        director = GetComponent<Director>();
        instance = this;
    }


    void Update()
    {

        forwardRaw = Input.GetAxis("VerticalLeft");
        leftRaw = Input.GetAxis("HorizontalLeft");


        forward = Input.GetAxis("VerticalLeft") > 0 ? Input.GetAxis("VerticalLeft") : 0;
        backward = -Input.GetAxis("VerticalLeft") > 0 ? -Input.GetAxis("VerticalLeft") : 0;
        right = Input.GetAxis("HorizontalLeft") > 0 ? Input.GetAxis("HorizontalLeft") : 0;
        left = -Input.GetAxis("HorizontalLeft") > 0 ? -Input.GetAxis("HorizontalLeft") : 0;

        AButton = Input.GetButton("AButton") ? 1 : 0;
        BButton = Input.GetButton("BButton") ? 1 : 0;
        XButton = Input.GetButton("XButton") ? 1 : 0;
        YButton = Input.GetButton("YButton") ? 1 : 0;

        RButton = Input.GetButton("RButton") ? 1 : 0;
        LButton = Input.GetButton("LButton") ? 1 : 0;

        RLTrigger = Input.GetAxis("RLTrigger");


        mouseXRaw = Input.GetAxis("VerticalRight");
        mouseYRaw = Input.GetAxis("HorizontalRight");
        mouseXPos = Input.GetAxis("VerticalRight") > 0 ? Input.GetAxis("VerticalRight") : 0;
        mouseXNeg = -Input.GetAxis("VerticalRight") > 0 ? -Input.GetAxis("VerticalRight") : 0;
        mouseYPos = Input.GetAxis("HorizontalRight") > 0 ? Input.GetAxis("HorizontalRight") : 0;
        mouseYNeg = -Input.GetAxis("HorizontalRight") > 0 ? -Input.GetAxis("HorizontalRight") : 0;

        startButton = Input.GetButton("StartButton") ? 1 : 0;
        backButton = Input.GetButton("BackButton") ? 1 : 0;

        upArrowButton = Input.GetAxis("VerticalCenter") > 0 ? Input.GetAxis("VerticalCenter") : 0;
        downArrowButton = -Input.GetAxis("VerticalCenter") > 0 ? -Input.GetAxis("VerticalCenter") : 0;
        leftArrowButton = Input.GetAxis("HorizontalCenter") > 0 ? Input.GetAxis("HorizontalCenter") : 0;
        rightArrowButton = -Input.GetAxis("HorizontalCenter") > 0 ? -Input.GetAxis("HorizontalCenter") : 0;

        rightArrowButton = -Input.GetAxis("HorizontalCenter") > 0 ? -Input.GetAxis("HorizontalCenter") : 0;
        rightArrowButton = -Input.GetAxis("HorizontalCenter") > 0 ? -Input.GetAxis("HorizontalCenter") : 0;

        LeftCentralButton = Input.GetButton("LeftCenterButton") ? 1 : 0;
        RightCentralButton = Input.GetButton("RightCenterButton") ? 1 : 0;

        if (director.DEBUG_MODE)
        {
            Debug.Log("forward :  " + forward + " backward :" + backward + " left : " + left + " right : " + right + "\nmouseXPos : " + mouseXPos + " mouseXNeg : " + mouseXNeg + " mouseYPos : " + mouseYPos + " mouseYNeg : " + mouseYNeg);
        }

        //forward =   Input.GetKey(KeyCode.W) ? 1 :  Input.GetAxis("Vertical") > 0   ?  Input.GetAxis("Vertical")  : 0;
        //backward =  Input.GetKey(KeyCode.S) ? 1 : -Input.GetAxis("Vertical") > 0   ? -Input.GetAxis("Vertical")  : 0;
        //left =      Input.GetKey(KeyCode.A) ? 1 : -Input.GetAxis("Horizontal") > 0 ? -Input.GetAxis("Horizontal"): 0;
        //right =     Input.GetKey(KeyCode.D) ? 1 :  Input.GetAxis("Horizontal") > 0 ?  Input.GetAxis("Horizontal"): 0;

        //jump = Input.GetKeyDown(KeyCode.Space) ? 1 : Input.GetButton("Jump")? 1 : 0;

        //force = Input.GetMouseButton(1) ? 1 : Input.GetButton("Force") ? 1 : 0;
        //bulletTime = Input.GetKeyDown(KeyCode.F) ? 1 : Input.GetButton("BulletTime") ? 1 : 0;

        //shoot = Input.GetMouseButton(0) ? 1 : Input.GetButton("Shoot") ? 1 : 0;

        //drop = Input.GetKeyDown(KeyCode.Q) ? 1 : Input.GetButton("Drop") ? 1 : 0;

        //screenZoom = Input.GetAxis("MouseWheel");


        ////forward    = Input.GetAxis("Horizontal");
        ////backward   = Input.GetAxis("Horizontal");
        ////left = Input.GetAxis("Vertical");
        ////right = Input.GetAxis("Vertical");

        ////jump = Input.GetAxis("Jump");

        ////force = Input.GetAxis("Force");
        ////bulletTime = Input.GetAxis("BulletTime");
        ////shoot = Input.GetAxis("Shoot");

        ////drop = Input.GetAxis("Drop");

        //if (screenZoom == 0)
        //{
        //    screenZoom = Input.GetAxis("ScreenZoom") * 1000;
        //}

        //mouseX = Input.GetAxis("MouseX");
        //mouseY = Input.GetAxis("MouseY");


        //infoInputText.text = "forward :  " + forward + " backward :" + backward + " left : " + left + " right : " + right + " jump : " + jump + "\nforce : " + force + " bulletTime : " + bulletTime + " shoot : " + shoot + " drop : " + drop + "\nscreenZoom : " + screenZoom + " MouseX: " + mouseX + " MouseY: " + mouseY;
    }
}