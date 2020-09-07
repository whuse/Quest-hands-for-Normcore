using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Normal.Realtime;

public class PlayerDataController : MonoBehaviour
{
    private GameObject holder;
    private RealtimeView realtimeView;
    private Realtime _realtime;
    private bool _alreadyConnected = false;
    private GameObject t;

    [SerializeField]
    private GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        _realtime = GetComponent<Realtime>();
        holder = GameObject.FindGameObjectWithTag("holder");
    }

    // Update is called once per frame
    void Update()
    {
        if (_realtime.connected)
        {
            if (_alreadyConnected == false)
            {
                SpawnTile();
                _alreadyConnected = true;
            }
            Vector3 playerPos = this.transform.GetChild(0).transform.position;
            t.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerPos.x.ToString("F2");
            t.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerPos.y.ToString("F2");
            t.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerPos.z.ToString("F2");

            Vector3 playerRot = this.transform.GetChild(0).transform.rotation.eulerAngles;
            t.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerRot.x.ToString("F2");
            t.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerRot.y.ToString("F2");
            t.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerRot.z.ToString("F2");
        }
    }

    private void SpawnTile()
    {
        t = GameObject.Instantiate(tile, tile.transform.position, Quaternion.identity);
        t.transform.SetParent(holder.transform, false);

        int clientID = GetComponent<RealtimeView>().ownerID;
        t.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "OwnerID: " + clientID;

    }
}
