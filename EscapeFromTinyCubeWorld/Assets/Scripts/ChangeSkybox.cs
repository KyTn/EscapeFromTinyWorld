using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour {

    public Skybox sky;

    public bool increasingExposure = false;
    public Vector2 minmaxExposure = new Vector2(1.5f, 2.5f);
    public float exposure, speedExposure = 0.2f;

    public Vector2 minmaxTintColor = new Vector2(180f/255f, 1f);
    public Color TintColor;
    public Color NextTintColor;

    // Use this for initialization
    void Start () {
        exposure = minmaxExposure.x;
        ChangeIncreaseExposure();
        TintColor = NextTintColor;
    }
	
	// Update is called once per frame
	void Update () {

        if (increasingExposure)
        {
            exposure += Time.deltaTime * speedExposure;
        }else
        {
            exposure -= Time.deltaTime * speedExposure;
        }

        if(exposure <= minmaxExposure.x)
        {
            increasingExposure = true;
            
        }
        else if(exposure >= minmaxExposure.y)
        {
            increasingExposure = false;
            ChangeIncreaseExposure();
        }

        TintColor = Color.Lerp(NextTintColor, TintColor, 0.998f);

        if (sky.material.HasProperty("_Exposure"))
        {
            sky.material.SetFloat("_Exposure", exposure);
        }

        if (sky.material.HasProperty("_Tint"))
        {
            sky.material.SetColor("_Tint", TintColor);
        }

    }


    public void ChangeIncreaseExposure()
    {
        int i = UnityEngine.Random.Range(0, 6);
        if (i == 0)
        {
            NextTintColor = new Color(minmaxTintColor.y, minmaxTintColor.x, minmaxTintColor.x, 1);
        }
        if (i == 1)
        {
            NextTintColor = new Color(minmaxTintColor.x, minmaxTintColor.y, minmaxTintColor.x, 1);

        }
        if (i == 2)
        {
            NextTintColor = new Color(minmaxTintColor.x, minmaxTintColor.x, minmaxTintColor.y, 1);

        }
        if (i == 3)
        {
            NextTintColor = new Color(minmaxTintColor.y, minmaxTintColor.y, minmaxTintColor.x, 1);
        }
        if (i == 4)
        {
            NextTintColor = new Color(minmaxTintColor.y, minmaxTintColor.x, minmaxTintColor.y, 1);

        }
        if (i == 5)
        {
            NextTintColor = new Color(minmaxTintColor.x, minmaxTintColor.y, minmaxTintColor.y, 1);

        }
    }
}
