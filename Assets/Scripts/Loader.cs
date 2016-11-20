using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
  public GameObject GameManagerPrefab;
  public TargetSystem TargetSystem;
  
  void Start() {
    if(GameManager.Instance == null) {
      Instantiate(GameManagerPrefab);
    }

    GameManager.Instance.TargetSystem = TargetSystem;
  }
}
