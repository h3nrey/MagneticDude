using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour {

    //Components
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator anim;

    //Movement
    [SerializeField] private float speed;

    private float inputX;

    //Floating
    [SerializeField]
    private float flyingCooldown;

    [SerializeField]
    private float verticalVel;

    [SerializeField]
    private float maxFloatSpeed;

    [SerializeField]
    private float floatFactor;

    private bool floating;

    private void Update() {
        HandleInput();
        SettingFacing();
        anim.SetFloat("InputX", Mathf.Abs(inputX));
    }

    private void FixedUpdate() {
        ApplyVelocity();
        Float();
    }

    private void HandleInput() {
        inputX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("fly")) {
            floating = true;
        }
        else {
            floating = false;
            CancelFloat();
        }
    }

    private void SettingFacing() {
        Quaternion rot = transform.localRotation;
        if (inputX > 0) {
            transform.localRotation = Quaternion.Euler(new Vector3(rot.x, 0, rot.z));
        }
        else if (inputX < 0) {
            transform.localRotation = Quaternion.Euler(new Vector3(rot.x, 180, rot.z));
        }
    }

    private void ApplyVelocity() {
        rb.velocity = new Vector2(speed * inputX, verticalVel);
    }

    private void CancelFloat() {
        verticalVel = rb.velocity.y;
    }

    private void Float() {
        if (floating) {
            verticalVel = Mathf.Min(verticalVel += floatFactor, maxFloatSpeed);
        }
    }
}