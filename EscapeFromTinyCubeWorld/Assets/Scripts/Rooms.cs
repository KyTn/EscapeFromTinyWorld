using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;


public struct RoomInfo
{
    public string name;
    public char[, ] data;


    public RoomInfo(string name)
    {
        data = new char[10, 10];
        this.name = name;

        for(int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                data[i, j] = 'W';
            }
        }
    }
}


public class Rooms : MonoBehaviour {

    public static Rooms instance;

    public List<RoomInfo> roomInfoList;

    public GameObject FacePrefab;
    public GameObject WallPrefab;




	// Use this for initialization
	void Awake () {
        instance = this;
        roomInfoList = new List<RoomInfo>();
        LoadRooms();


        //InstantiateFaceRoom();
    }
	
	// Update is called once per frame
	void Update () {
	
	}



    private void LoadRooms()
    {
        TextAsset txt = (TextAsset)Resources.Load("Rooms", typeof(TextAsset));
        string content = txt.text;


        string[] lines = content.Split(',');

        int RoomID = 0;
        int X = 0;
        int i = 0;

        while (i < lines.Length)
        {
            if (lines[i].Contains("START_ROOM"))
            {
                RoomID++;
                X = 0;
                roomInfoList.Add(new RoomInfo("RoomFace" + RoomID));
            }
            else
            {
                char[] chars = lines[i].ToCharArray();

                int charsCount = 0;
                for (int j = 0; j < chars.Length || charsCount < 10; j++)
                {
                    if (chars[j] == 'W' || chars[j] == '.' || chars[j] == 'T' || chars[j] == 'M' || chars[j] == 'C' || chars[j] == 'G')
                    {
                        roomInfoList[roomInfoList.Count - 1].data[X, charsCount] = chars[j];
                        charsCount++;
                    }
                }
                X++;
            }
            i++;
        }
        
    }

    
    public GameObject InstantiateFaceRoom()
    {
        RoomInfo roomInfo = roomInfoList[Random.Range(0, roomInfoList.Count)];

        GameObject face = Instantiate(FacePrefab) as GameObject;
        Face f = face.GetComponent<Face>();
        GameObject wall;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if(roomInfo.data[i, j] == 'W')
                {
                    wall = Instantiate(WallPrefab) as GameObject;
                    wall.transform.parent = face.transform;

                    wall.transform.localPosition= new Vector3(i * 0.1f - 0.45f, 0.145f, j * 0.1f - 0.45f);
                }
                else if (roomInfo.data[i, j] == 'T')
                {
                    f.Torrets.Add(new Vector3(i * 0.1f - 0.45f, 0, j * 0.1f - 0.45f));
                }
                else if (roomInfo.data[i, j] == 'M')
                {
                    f.Monsters.Add(new Vector3(i * 0.1f - 0.45f, 0.145f, j * 0.1f - 0.45f));

                }
                else if (roomInfo.data[i, j] == 'C')
                {
                    f.Coins.Add(new Vector3(i * 0.1f - 0.45f, 0.145f, j * 0.1f - 0.45f));

                }
                else if (roomInfo.data[i, j] == 'G')
                {
                    f.Gems.Add(new Vector3(i * 0.1f - 0.45f, 0.145f, j * 0.1f - 0.45f));

                }
            }
        }


        return face;
    }

}



