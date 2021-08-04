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
        // Transform t = GetComponent<Transform>();
        // gameObject.SetActive(false);
        // Debug.Log("What it do baby");
        // GameObject g = Instantiate(brokenObj, t);
        // yield return new WaitForSeconds(2);
        // Destroy(g);
              gameObject.SetActive(false);

         var pos = gameObject.transform.position;
         var rotation = gameObject.transform.rotation;
         Instantiate(brokenObj,pos,rotation);
         Destroy(brokenObj);
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