using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
  public GameObject GameManagerPrefab;
  public TargetSystem TargetSystem;
  public HUD HUDSystem;
  
  void Start() {
    if(GameManager.Instance == null) {
      Instantiate(GameManagerPrefab);
    }

    GameManager.Instance.TargetSystem = TargetSystem;
    GameManager.Instance.HUDSystem = HUDSystem;
  }
}
