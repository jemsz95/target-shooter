using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Interactable : MonoBehaviour {
  public string Action;

  public UnityEvent LookEnter;
  public UnityEvent LookExit;
  public UnityEvent LookStay;
  public UnityEvent Interact;

  public void OnLookEnter() {
    LookEnter.Invoke();
  }

  public void OnLookExit() {
    LookExit.Invoke();
  }

  public void OnLookStay() {
    LookStay.Invoke();
  }

  public void OnInteract() {
    Interact.Invoke();
  }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
