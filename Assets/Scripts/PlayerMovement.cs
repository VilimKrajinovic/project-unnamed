using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController characterController;
    public Transform cam;
    public float playerMovementSpeed = 7f;
    private float turnSmoothVelocity;
    private float forwardAngle;
    private Vector3 forwardDirection;

    // Update is called once per frame
    void Update() {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        forwardAngle = GetForwardAngle();
        forwardDirection = CalculateForwardDirection(forwardAngle);
        ChangeDirectionToForwardAngle(ref moveDirection, forwardAngle);
        MoveTowards(moveDirection);
    }
    private float GetForwardAngle() {
        if (IsRightMouseButtonHeld()) {
            return GetCameraRotation();
        }
        return forwardAngle;
    }
    private Vector3 CalculateForwardDirection(float forwardAngle) {
        return Quaternion.AngleAxis(forwardAngle, Vector3.up) * Vector3.forward;
    }
    private void ChangeDirectionToForwardAngle(ref Vector3 direction, float forwardAngle) {
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, forwardAngle, ref turnSmoothVelocity, 0.1f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        direction = Quaternion.AngleAxis(forwardAngle, Vector3.up) * direction;
    }

    private void MoveTowards(Vector3 direction) {
        characterController.Move(direction * Time.deltaTime * playerMovementSpeed);
    }

    private float GetCameraRotation() {
        Vector3 forward = Vector3.forward;
        return Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    }

    private bool IsRightMouseButtonHeld() {
        return Input.GetMouseButton(1);
    }
}