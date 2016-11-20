using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour {

  public float DistanceThreshold;
  public float Speed;

  private Vector3 target;

  private Vector3 targetDelta;

  public void Launch(Vector3 target) {
    this.target = target;
  }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    targetDelta = target - transform.position;
	  
    if(targetDelta.magnitude > DistanceThreshold) {
      transform.position = transform.position + (targetDelta.normalized * Speed * Time.deltaTime);
    } else {
      Destroy(gameObject);
    }
	}

  void OnTriggerEnter(Collider other) {
    Destroy(gameObject);
  }
}
