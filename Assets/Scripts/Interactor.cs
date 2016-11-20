using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {
  public float InteractDistance;
  public Transform CameraTransform;
  public LayerMask InteractableMask;
  
  public Interactable Target;

  private RaycastHit hit;
  private Interactable previousTarget;

	// Update is called once per frame
	void Update () {
	  if(Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, InteractDistance, InteractableMask)) {
      Target = hit.collider.GetComponent<Interactable>();

      if(previousTarget != Target) {
        Target.OnLookEnter();
      } else {
        Target.OnLookStay();
      }

      if(Input.GetButtonDown("Action")) {
        Target.OnInteract();
      }
    } else {
      if(previousTarget != null) {
        Target = null;

        previousTarget.OnLookExit();
      }
    }
   
    previousTarget = Target;
	}
}
