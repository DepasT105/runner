using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{


    public GameObject brokenObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            Destroy(gameObject);
        }


    }
}