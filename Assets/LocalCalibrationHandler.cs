using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCalibrationHandler : MonoBehaviour
{
    public GameObject normcoreAvatar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position != normcoreAvatar.transform.position)
        {
            this.transform.position = normcoreAvatar.transform.position;
        }
    }
}
