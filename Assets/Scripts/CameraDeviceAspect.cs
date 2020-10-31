using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeviceAspect : MonoBehaviour
{
    [SerializeField] Transform Celling = null;

    void Start()
    {
        if (Screen.width/Screen.height < 1) //mobile
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -45);
            Celling.position = new Vector3(Celling.position.x, Celling.position.y, 32);
        }
        else //square
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -12);
            Celling.position = new Vector3(Celling.position.x, Celling.position.y, 16);
        }
    }
}
