using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform player;
  Vector3 cameraPos ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      cameraPos = new Vector3(player.position.x,8f, player.position.z-13 );
transform.position = cameraPos;
    }
}
