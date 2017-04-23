
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System;

public class RubikControllerSplash : MonoBehaviour {

    public enum RotationAxis
    {
        X_1_POS,
        X_2_POS,
        X_3_POS,
        X_1_NEG,
        X_2_NEG,
        X_3_NEG,
        Z_1_POS,
        Z_2_POS,
        Z_3_POS,
        Z_1_NEG,
        Z_2_NEG,
        Z_3_NEG
    }

    public static RubikControllerSplash instance;

    public RubikCubeSplash RubikCubePrefab;

    public RubikCubeSplash[,,] cubes;
    public Vector3 CENTER;
    public GameObject RotationAuxiliar;

    public bool IsRotating = false;


    // Use this for initialization
    void Awake () {
        instance = this;
        cubes = new RubikCubeSplash[3, 3, 3];

        ConstructRubikWorld();
    }

    /*
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                RotateToAxis(RotationAxis.X_1_NEG);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                RotateToAxis(RotationAxis.X_2_NEG);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                RotateToAxis(RotationAxis.X_3_NEG);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                RotateToAxis(RotationAxis.Z_1_NEG);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                RotateToAxis(RotationAxis.Z_2_NEG);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha6))
            {
                RotateToAxis(RotationAxis.Z_3_NEG);
            }
        }else
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                RotateToAxis(RotationAxis.X_1_POS);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                RotateToAxis(RotationAxis.X_2_POS);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                RotateToAxis(RotationAxis.X_3_POS);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                RotateToAxis(RotationAxis.Z_1_POS);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                RotateToAxis(RotationAxis.Z_2_POS);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha6))
            {
                RotateToAxis(RotationAxis.Z_3_POS);
            }
        }
        
    }
    */


    #region CONSTRUCT WORLD

    void ConstructRubikWorld()
    {
        RubikCubeSplash r;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    r= (RubikCubeSplash) Instantiate(RubikCubePrefab, new Vector3(x, y, z), Quaternion.identity);
                    r.name = "RC(" + x + "," + y + "," + z + ")";
                    r.transform.parent = transform;
                    cubes.SetValue(r,x,y,z);
                }
            }
        }
    }

    #endregion



    #region ROTATION CONTROLLER


    public void RotateToAxis(RotationAxis rotAxis)
    {
        if (IsRotating) return;
        //StartCoroutine(Rotate_Courutine(rotAxis));

        IsRotating = true;


        ReparentAll();
        ParentRubikCubes_ToRotation(rotAxis);

        RotationAuxiliar.transform.DOLocalRotate(
            AngleToRotate(rotAxis),
            1,
            RotateMode.LocalAxisAdd
            ).OnComplete(() => { IsRotating = false; ReparentAll(); UpdateMatrix(); });

        

        //ShowCubesInfo();


    }

    void UpdateMatrix( )
    {
        Vector3 origin = new Vector3(0, 0, -1);
        Vector3 direction = new Vector3(0, 0, 1);
        float distance = 4;
        RaycastHit[] hits;

        int z;

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                origin.Set(x, y, -1);
                
                hits = Physics.RaycastAll(origin, direction, distance);

                for(int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.gameObject.CompareTag("RubikCube"))
                    {
                        z = Mathf.RoundToInt(hits[i].collider.gameObject.transform.position.z);
                        cubes.SetValue(hits[i].collider.gameObject.GetComponent<RubikCubeSplash>(), x, y, z);
                        cubes[x, y, z].name = "RC(" + x + "," + y + "," + z + ")";
                        Debug.DrawLine(origin, origin + (direction * distance), Color.red, 3);

                    }
                }
            }
        }
    }




    // Angulo que debería rotar en funcion de cada eje
    Vector3 AngleToRotate(RotationAxis rotAxis)
    {
        if (rotAxis == RotationAxis.X_1_POS ||
            rotAxis == RotationAxis.X_2_POS ||
            rotAxis == RotationAxis.X_3_POS) return new Vector3(-90, 0, 0);

        if (rotAxis == RotationAxis.X_1_NEG ||
            rotAxis == RotationAxis.X_2_NEG ||
            rotAxis == RotationAxis.X_3_NEG) return new Vector3(90, 0, 0);

        if (rotAxis == RotationAxis.Z_1_POS ||
            rotAxis == RotationAxis.Z_2_POS ||
            rotAxis == RotationAxis.Z_3_POS) return new Vector3(0, 0, -90);

        if (rotAxis == RotationAxis.Z_1_NEG ||
        rotAxis == RotationAxis.Z_2_NEG ||
        rotAxis == RotationAxis.Z_3_NEG) return new Vector3(0, 0, 90);

        return Vector3.zero;
    }



    // cubo que sería el centro de la rotacion en funcion de cada eje
    RubikCubeSplash CenterOfRotation(RotationAxis rotAxis)
    {
        switch (rotAxis)
        {
            case RotationAxis.X_1_POS: return cubes[0, 1, 1];
            case RotationAxis.X_1_NEG: return cubes[0, 1, 1];


            case RotationAxis.X_2_POS: return cubes[1, 1, 1];
            case RotationAxis.X_2_NEG: return cubes[1, 1, 1];

            case RotationAxis.X_3_POS: return cubes[2, 1, 1];
            case RotationAxis.X_3_NEG: return cubes[2, 1, 1];
                                       
            case RotationAxis.Z_1_POS: return cubes[1, 1, 0];
            case RotationAxis.Z_1_NEG: return cubes[1, 1, 0];
                                       
            case RotationAxis.Z_2_POS: return cubes[1, 1, 1];
            case RotationAxis.Z_2_NEG: return cubes[1, 1, 1];
                                       
            case RotationAxis.Z_3_POS: return cubes[1, 1, 2];
            case RotationAxis.Z_3_NEG: return cubes[1, 1, 2];

            default: return cubes[0, 0, 0];
        }
    }

    #region PARENTING FUNTIONS
    void ParentRubikCubes_ToRotation(RotationAxis rotAxis)
    {

        RubikCubeSplash parent = CenterOfRotation(rotAxis);
        RotationAuxiliar.transform.localPosition = parent.transform.localPosition;
        
        if (rotAxis == RotationAxis.X_1_POS || rotAxis == RotationAxis.X_1_NEG)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    cubes[0, y, z].transform.parent = RotationAuxiliar.transform;
                }
            }
        }
        else if(rotAxis == RotationAxis.X_2_POS || rotAxis == RotationAxis.X_2_NEG)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    cubes[1, y, z].transform.parent = RotationAuxiliar.transform;
                }
            }

        }
        else if (rotAxis == RotationAxis.X_3_POS || rotAxis == RotationAxis.X_3_NEG)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    cubes[2, y, z].transform.parent = RotationAuxiliar.transform;
                }
            }
        }
        else if(rotAxis == RotationAxis.Z_1_POS || rotAxis == RotationAxis.Z_1_NEG)
        {

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    cubes[x, y, 0].transform.parent = RotationAuxiliar.transform;
                }
            }


        }
        else if (rotAxis == RotationAxis.Z_2_POS || rotAxis == RotationAxis.Z_2_NEG)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    cubes[x, y, 1].transform.parent = RotationAuxiliar.transform;
                }
            }
        }
        else if(rotAxis == RotationAxis.Z_3_POS || rotAxis == RotationAxis.Z_3_NEG)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    cubes[x, y, 2].transform.parent = RotationAuxiliar.transform;
                }
            }
        }

        
    }

    void ReparentAll()
    {
        // Desparentamos 
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    if(cubes[x, y, z] != null) cubes[x, y, z].transform.parent = transform;
                }
            }
        }

        // ponemos el auxiliar para que se pueda usar de nuevo
        RotationAuxiliar.transform.localPosition = Vector3.zero;
        RotationAuxiliar.transform.localRotation = Quaternion.identity;
    }
    #endregion

    #endregion






    void ShowCubesInfo()
    {
        String s = "";
        

        for(int x = 0; x < 3; x++)
        {
            s += "Showing X= " + x + "\n";
            
            for (int y = 0; y < 3; y++)
            {
                for(int z = 0; z < 3; z++)
                {
                    s += "   (" + y + "," + z + ") : " + cubes[x, y, z].name;
                }
                s += "\n";
            }
            s += "\n";
        }

    

        Debug.Log(s);
    }
}
