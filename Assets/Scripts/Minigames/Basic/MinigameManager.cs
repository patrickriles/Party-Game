using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MinigameManager : MonoBehaviour {

    public List<PlayerWithMovement> playerObjects = new List<PlayerWithMovement>();

    public GameObject Persistant;

    public PlayerWithMovement playerOne;
    public PlayerWithMovement playerTwo;
    public PlayerWithMovement playerThree;
    public PlayerWithMovement playerFour;

    public TextMeshProUGUI minigameWinner;
    public PlayerWithMovement winner;

    private bool miniGameOver = false;

    void Start() {
        playerObjects.Add(playerOne);
        playerObjects.Add(playerTwo);
        playerObjects.Add(playerThree);
        playerObjects.Add(playerFour);
        Persistant = GameObject.FindWithTag("Persistant");
        Persistant.SetActive(false);
    }

    void Update() {
        if(getRemainingPlayers() == 1) {
            miniGameOver = true;
            winner = playerObjects[0];
            minigameWinner.text = $"{playerObjects[0].GetPlayerName()} wins!!";
            Persistant.SetActive(true);
            SceneManager.LoadScene("SimpleMap");
        }
    }

    public int getRemainingPlayers() {
        return playerObjects.Count;
    }

    public void removePlayerFromArray(PlayerWithMovement player) {
        int index = playerObjects.IndexOf(player);
        playerObjects.RemoveAt(index);
    }

    public bool getMinigameOver() {
        return miniGameOver;
    }
}
