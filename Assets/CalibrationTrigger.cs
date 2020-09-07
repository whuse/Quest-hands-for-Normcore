using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CalibrationTrigger : MonoBehaviour
{
    public int tileID = 1234;
    public List<Vector3> playerPos = new List<Vector3>();
    public List<Quaternion> playerRot = new List<Quaternion>();

    private TileController tileController;
    private bool calibrating = false;
    private GameObject calibrationPoint;

    // Start is called before the first frame update
    void Start()
    {
        tileController = this.transform.parent.parent.GetComponent<TileController>();
        calibrationPoint = GameObject.Find("CalibrationPoint");

    }

    // Update is called once per frame
    void Update()
    {
        if (calibrating == true)
        {
            GameObject player = tileController.players[tileID];

            for (int i = 0; i < 10; i++)
            {
                playerPos.Add(player.transform.GetChild(0).transform.position);
                playerRot.Add(player.transform.GetChild(0).transform.rotation);
            }

            var posAverage = new Vector3(playerPos.Average(x => x.x), playerPos.Average(x => x.y), playerPos.Average(x => x.z));
            var rotAverage = new Quaternion(playerRot.Average(x => x.x), playerRot.Average(x => x.y), playerRot.Average(x => x.z), playerRot.Average(x => x.w));

            Vector3 offsetPos = calibrationPoint.transform.position - posAverage;
            player.transform.position = offsetPos;
            Quaternion offsetRot = calibrationPoint.transform.rotation * Quaternion.Inverse(rotAverage);
            player.transform.rotation = player.transform.rotation * offsetRot;

            CalibrationComplete();
        }
    }

    public void Calibrating()
    {
        calibrating = true;
    }

    public void CalibrationComplete()
    {
        calibrating = false;

        playerPos.Clear();
        playerRot.Clear();

    }
}
