using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public static float[] laneXOne = {-8f, -3f };
    public static float[] laneXTwo = {8f, 3f };


  #region Singleton

  public static GameManager instance;

  void Awake () {
    instance = this;
  }

  #endregion
  // Start is called before the first frame update
  // void Start()
  // {
  //
  // }
  //
  // // Update is called once per frame
  // void Update()
  // {
  //
  // }
}