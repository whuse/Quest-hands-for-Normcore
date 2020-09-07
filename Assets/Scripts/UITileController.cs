using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class UITileController : MonoBehaviour
{
    //UI prefab to spawn in for each player
    public GameObject tilePrefab;

    void Start()
    {

    }

    void Update()
    {
        //How to find prefabs of players that enter the server
        GameObject.FindGameObjectsWithTag("VR Rig");

        foreach(GameObject vrRig in GameObject.FindGameObjectsWithTag("VR Rig"))
        {
            //Static int from player prefabs in the scene
            int ownerID = vrRig.GetComponent<RealtimeView>().ownerID;
            //position and rotation data from players in the scene
            Vector3 playerPos = vrRig.transform.GetChild(0).transform.position;
            Vector3 playerRot = vrRig.transform.GetChild(0).transform.rotation.eulerAngles;

            //tile.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "OwnerID: " + vrRig.GetComponent<RealtimeView>().ownerID.ToString();
        }
        


    }
}
