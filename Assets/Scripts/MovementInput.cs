using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

  public float Speed;
  public float JumpPower;
  public Vector2 LookSensitivity;
  public Transform CameraTransform;
  public CursorLockMode CursorMode;

  private Vector2 clampRotation = new Vector2(360, 90);
  private CharacterController character;
  private Vector3 moveDirection;
  private Quaternion originalRotation;
  private float rotationX = 0f;
  private float rotationY = 0f;

  public static float ClampAngle (float angle, float min, float max) {
    if (angle < -360f || angle > 360f) {
      angle %= 360;
    } 
    
    return Mathf.Clamp (angle, min, max);
  }

  Quaternion getInputRotation() {
    rotationX += Input.GetAxis("Mouse X") * LookSensitivity.x;
    rotationY += Input.GetAxis("Mouse Y") * LookSensitivity.y;

    Quaternion lookRotationX = Quaternion.AngleAxis(ClampAngle(rotationX, -clampRotation.x, clampRotation.x), Vector3.up);
    Quaternion lookRotationY = Quaternion.AngleAxis(ClampAngle(rotationY, -clampRotation.y, clampRotation.y), Vector3.left);

    return lookRotationX * lookRotationY;
  }

  Vector3 getInputMovement() {
    if(character.isGrounded) {
      //Only move if character is on the ground
      moveDirection.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

      moveDirection = CameraTransform.rotation * moveDirection;

      moveDirection.Normalize();
      moveDirection *= Speed;

      if(Input.GetButton("Jump")) {
        moveDirection.y = JumpPower;
      } else {
        moveDirection.y = 0;
      }
    } else {
      //Simulate gravity
      moveDirection.y -= 9.81f * Time.deltaTime;
    }

    return moveDirection;
  }

  // Use this for initialization
  void Start () {
    Cursor.lockState = CursorMode;

    character = GetComponent<CharacterController>();

    if(CameraTransform == null) {
      CameraTransform = Camera.main.transform;
    }

    originalRotation = CameraTransform.localRotation;
  }
  
  // Update is called once per frame
  void Update () {
    CameraTransform.localRotation = originalRotation * getInputRotation();
    character.Move(getInputMovement() * Time.deltaTime);
  }
}
