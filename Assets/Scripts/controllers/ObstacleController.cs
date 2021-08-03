using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{


    public GameObject brokenObj;
    GameObject thisObj;

    // Start is called before the first frame update
    void Start()
    {
        thisObj = GetComponent<GameObject>();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            Transform oldTrans = obj.transform;
            Destroy(thisObj);
        }


    }
}