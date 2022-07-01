using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed = 1f;

    [SerializeField]
    private int playerIndex = 0;

    private CharacterController controller;
    private Rigidbody rigidBody;
    public string PlayerName;
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    void Awake() {
        controller = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public void SetInputVector(Vector2 direction) {
        inputVector = direction;
    }

    void Update() {
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= MoveSpeed;

        rigidBody.AddForce(moveDirection);
    }

    public int GetPlayerIndex() {
        return playerIndex;
    }

    public string GetPlayerName() {
        return PlayerName;
    }
}
