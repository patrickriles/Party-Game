using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {

    private PlayerMovement playerMovement;
    private PlayerInput playerInput;

    void Awake() {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<PlayerMovement>();
        var index = playerInput.playerIndex;
        
        playerMovement = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    public void OnMovement(InputValue value) {
        playerMovement.SetInputVector(value.Get<Vector2>());
    }
}
