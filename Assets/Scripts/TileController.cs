using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Normal.Realtime;
using TMPro;


public class TileController : MonoBehaviour
{
    public GameObject tilePrefab;
    public List<GameObject> players;
    public List<GameObject> tiles;

    private Realtime _realtime;
    private bool _alreadyConnected = false;

    void Start()
    {
        foreach (GameObject vrRig in players)
        {
            _alreadyConnected = false;
        }
    }
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("VR Rig").ToList();

        foreach (GameObject vrRig in players)
        {
            if (_alreadyConnected == false)
            {
               AddTile(vrRig);
               _alreadyConnected = true;
            }

            int i = players.IndexOf(vrRig);
            GameObject t = tiles[i];
            Vector3 playerPos = vrRig.transform.GetChild(0).transform.position;
            t.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerPos.x.ToString("F2");
            t.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerPos.y.ToString("F2");
            t.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerPos.z.ToString("F2");

            Vector3 playerRot = vrRig.transform.GetChild(0).transform.rotation.eulerAngles;
            t.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerRot.x.ToString("F0");
            t.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerRot.y.ToString("F0");
            t.transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerRot.z.ToString("F0");
        }
    }
    private void AddTile(GameObject vrRig)
    {
        GameObject tile = Instantiate(tilePrefab) as GameObject;
        tile.transform.parent = this.transform;
        tile.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "OwnerID: " + players.IndexOf(vrRig);
        tile.transform.GetChild(3).GetComponent<CalibrationTrigger>().tileID = players.IndexOf(vrRig); 
        tiles.Add(tile);

    }

    //calibration method called by Calibration UI button press
    void Calibrate()
    {
        //get next 10 transform updates
        //calculate average of last 10 transforms
        //subtract average postiion and rotation from designated calibration point
        //apply calculated offset to OVR Rig parent and PlayerAvatar parent
    }
}
