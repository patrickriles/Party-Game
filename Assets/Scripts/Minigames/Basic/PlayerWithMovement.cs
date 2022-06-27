using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerWithMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    private Vector3 movement;
    private Rigidbody rb;
    public string PlayerName;

    void OnMove(InputValue value) {
        movement = value.Get<Vector3>();
    }

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Movement();
        rb.velocity = checkMaxVelocityReached(rb);
    }

    private void Movement() {
        Vector3 adjustedMovement = movement * movementSpeed;
        rb.AddForce(adjustedMovement);
    }

    private Vector3 checkMaxVelocityReached(Rigidbody rigidbody) {
        Vector3 newVelocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
        if(newVelocity.x > 10){
            newVelocity.x = 10;
        } 
        else if (newVelocity.x < -10){
            newVelocity.x = -10;
        }
        if(newVelocity.z > 10){
            newVelocity.z = 10;
        }
        else if (newVelocity.z < -10) {
            newVelocity.z = -10;
        }
        return newVelocity;
    }

    public string GetPlayerName() {
        return PlayerName;
    }
}
