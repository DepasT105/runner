using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialController : MonoBehaviour {
    Rigidbody rb;

    private float specPosX = 0;
    public float timeBeforeNextSpecial = 5.0f;
    public float distanceTraveled = 25;
    public float specialSpeed = 5000;
    private float canShoot = 0f;
    // Start is called before the first frame update
    void Start () {
    }

     void OnCollisionEnter (Collision collision) {
    GameObject obj = collision.gameObject;
    if (obj.tag == "Obstacle") {
     Debug.Log("Destroy Wall");
      Destroy(gameObject);
    }
    
  }
}