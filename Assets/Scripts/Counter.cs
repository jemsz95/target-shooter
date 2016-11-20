using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {
  public void StartGame() {
    GameManager.Instance.StartGame();
  }
}
