using UnityEngine;
using System.Collections;

public class RubikCube : MonoBehaviour {

    public GameObject FaceXP;
    public GameObject FaceXN;
    public GameObject FaceYP;
    public GameObject FaceYN;
    public GameObject FaceZP;
    public GameObject FaceZN;





    MeshRenderer meshRenderer;
    Material material; 


	// Use this for initialization
	void Start () {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        //material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));


        Vector3 pos = transform.localPosition + Vector3.one * 0.5f;
        Vector3 neg = transform.localPosition - Vector3.one * 0.5f;

        if (pos.x > 2.1f)
        {
            FaceXP = Rooms.instance.InstantiateFaceRoom();
            FaceXP.transform.localPosition = transform.localPosition + Vector3.right * 0.5f;

            Quaternion q = Quaternion.identity;
            q.eulerAngles = new Vector3(0,0,-90);
            FaceXP.transform.localRotation = q;

            GameManager.instance.AddFace(FaceXP);

        }
        else if (neg.x < -0.1f)
        {
            FaceXN = Rooms.instance.InstantiateFaceRoom();
            FaceXN.transform.localPosition = transform.localPosition - Vector3.right * 0.5f;

            Quaternion q = Quaternion.identity;
            q.eulerAngles = new Vector3(0, 0, 90);
            FaceXN.transform.localRotation = q;

            GameManager.instance.AddFace(FaceXN);
        }


        if (pos.y > 2.1f)
        {
            FaceYP = Rooms.instance.InstantiateFaceRoom();
            FaceYP.transform.localPosition = transform.localPosition + Vector3.up * 0.5f;

            Quaternion q = Quaternion.identity;
            q.eulerAngles = new Vector3(0, 0, 0);
            FaceYP.transform.localRotation = q;

            GameManager.instance.AddFace(FaceYP);
        }
        else if (neg.y < -0.1f)
        {
            FaceYN = Rooms.instance.InstantiateFaceRoom();
            FaceYN.transform.localPosition = transform.localPosition - Vector3.up * 0.5f;

            Quaternion q = Quaternion.identity;
            q.eulerAngles = new Vector3(180, 0, 0);
            FaceYN.transform.localRotation = q;

            GameManager.instance.AddFace(FaceYN);
        }



        if (pos.z > 2.1f)
        {
            FaceZP = Rooms.instance.InstantiateFaceRoom();
            FaceZP.transform.localPosition = transform.localPosition + Vector3.forward * 0.5f;

            Quaternion q = Quaternion.identity;
            q.eulerAngles = new Vector3(90, 0, 0);
            FaceZP.transform.localRotation = q;

            GameManager.instance.AddFace(FaceZP);
        }
        else if (neg.z < -0.1f)
        {
            FaceZN = Rooms.instance.InstantiateFaceRoom();
            FaceZN.transform.localPosition = transform.localPosition - Vector3.forward * 0.5f;

            Quaternion q = Quaternion.identity;
            q.eulerAngles = new Vector3(-90, 0, 0);
            FaceZN.transform.localRotation = q;

            GameManager.instance.AddFace(FaceZN);
        }


        if(FaceXP != null) FaceXP.transform.parent = transform;
        if(FaceXN != null) FaceXN.transform.parent = transform;
        if(FaceYP != null) FaceYP.transform.parent = transform;
        if(FaceYN != null) FaceYN.transform.parent = transform;
        if(FaceZP != null) FaceZP.transform.parent = transform;
        if(FaceZN != null) FaceZN.transform.parent = transform;
    }

    // Update is called once per frame
    void Update () {
        //material.color = new Color(transform.position.x, transform.position.y, transform.position.z);
    }


    public void SnapPosition()
    {
        transform.position.Set(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
    }


    


}
