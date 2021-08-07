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

    void DestroyEffect()
    {
        gameObject.SetActive(false);
        var pos = gameObject.transform.position;
        var rotation = gameObject.transform.rotation;
        var brokenObjInstance = Instantiate(brokenObj, pos, rotation);
        Destroy(gameObject);

    }


    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player" || obj.tag == "Special")
        {
            // StartCoroutine(DestroyEffect());
            DestroyEffect();

        }


    }
}