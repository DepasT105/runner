using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitplz());
        //
    }

    IEnumerator waitplz(){
    yield return new WaitForSeconds (5);
     Destroy(gameObject);

    }
}
