 using System.Collections.Generic;
 using System.Collections;
 using UnityEngine;

 public class TrackEditor : MonoBehaviour {

   public GameObject[] trackPieces;
   public GameObject[] obstaclePieces;
   float[] playerOneX = GameManager.laneXOne;
   float[] playerTwoX = GameManager.laneXTwo;
   public int trackLength = 100;
   public Transform obs;
   // Start is called before the first frame update
   void Start () {
     buildMap (50);
     buildObstacleCourse (5, 300, 50, 100);

   }

   // Update is called once per frame
   void Update () {

   }
   void OnCollisionEnter (Collision collision) {

   }
   void buildMap (int length) {
     var track = trackPieces[0]; //4lanestraight

     for (int i = 0; i < length; i++) {
       GameObject curObs = Instantiate (track, obs, false);
       curObs.transform.position = (new Vector3 (0, 1, i * trackLength));

     }
   }

   void buildObstacleCourse (int levels, int length, int minDistance, int maxDistance) {
     int zPos = 0;
     for (int level = 1; level <= levels + 1; level++) {
       var distancebtwn = maxDistance - (((level - 1) / (float) levels) * (maxDistance - minDistance));
       var totalRows = Mathf.RoundToInt (length / distancebtwn);
       placeObstacles (zPos, totalRows, Mathf.RoundToInt (distancebtwn));
       zPos += totalRows * Mathf.RoundToInt (distancebtwn);

     }

   }

   void placeObstacles (int startZPos, int totalRows, int distancebtwn) {

     for (var i = 0; i <= totalRows; i++) {
       var nextObs = Random.Range (0, 3);
       var obsType = Random.Range (0, obstaclePieces.Length);
       GameObject curObs = Instantiate (obstaclePieces[obsType], obs, false);
       GameObject curObsP2 = Instantiate (obstaclePieces[obsType], obs, false);
  

       switch (nextObs) {
         case 2:
           curObs.transform.position = (new Vector3 (playerOneX[0], curObs.transform.position.y, startZPos + (i * distancebtwn)));
           curObsP2.transform.position = (new Vector3 (playerTwoX[0], curObs.transform.position.y, startZPos + (i * distancebtwn)));

           GameObject curObs2 = Instantiate (obstaclePieces[0], obs, false);
           GameObject curObsP2_ = Instantiate (obstaclePieces[0], obs, false);

           curObs2.transform.position = (new Vector3 (playerOneX[1], curObs2.transform.position.y, startZPos + (i * distancebtwn)));
           curObsP2_.transform.position = (new Vector3 (playerTwoX[1], curObsP2_.transform.position.y, startZPos + (i * distancebtwn)));

           break;
         case 1:
           curObs.transform.position = (new Vector3 (playerOneX[1], curObs.transform.position.y, startZPos + (i * distancebtwn)));
           curObsP2.transform.position = (new Vector3 (playerTwoX[1], curObsP2.transform.position.y, startZPos + (i * distancebtwn)));

           break;
         case 0:
           curObs.transform.position = (new Vector3 (playerOneX[0], curObs.transform.position.y, startZPos + (i * distancebtwn)));
           curObsP2.transform.position = (new Vector3 (playerTwoX[0], curObsP2.transform.position.y, startZPos + (i * distancebtwn)));

           break;
         default:
           break;
       }

     }

   }

 }