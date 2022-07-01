using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine;

public class PlayerInputHandlerBoard : MonoBehaviour {

    private Player player;
    private PlayerInput playerInput;
    private GameManager gameManager;

    void Awake() {
        playerInput = GetComponent<PlayerInput>();
        gameManager = FindObjectOfType<GameManager>();
        var players = FindObjectsOfType<Player>();
        var index = playerInput.playerIndex;
        
        player = players.FirstOrDefault(p => p.GetPlayerIndex() == index);
    }

    public void OnInteract() {
        if (gameManager.getCurrentPlayerTurn().getPlayerName() == player.getPlayerName()) {
           player.RollDice(); 
        }
    }

    public void OnGoBack() {
 
    }

    public void OnNavigate(InputValue value) {

    }
}
