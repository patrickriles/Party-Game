using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {

    public string playerName;
    public Color playerColor;
    private Color brown = new Color(0.6f,0.2f,0.2f);
    public Spaces spaces;
    public TextMeshProUGUI dice;
    public GameObject currentSpace;
    public GameManager gameManager;
    public int currency = 0;

    public string diceKey;

    void Start() {
        gameObject.transform.GetChild(0).GetChild(1).GetComponentsInChildren<Renderer>()[0].materials[0].color = playerColor;
        gameObject.transform.GetChild(0).GetChild(1).GetComponentsInChildren<Renderer>()[0].materials[1].color = Color.white;
        gameObject.transform.GetChild(0).GetChild(1).GetComponentsInChildren<Renderer>()[0].materials[2].color = brown;
    }

    void Update() {
        if(currentSpace == null) {
            MoveToSpace(spaces.getStartSpace());
            currentSpace = spaces.getStartSpace();
        }
        if (Input.GetKeyDown(diceKey)) {
            if (gameManager.getCurrentPlayerTurn().getPlayerName() == this.getPlayerName() && !gameManager.getMinigameTime()) {
                RollDice();
            }
        }
    }

    void MoveToSpace(GameObject spaceToMove) {
        Vector3 newPosition = new Vector3(spaceToMove.transform.position.x, spaceToMove.transform.position.y + 1.5f, spaceToMove.transform.position.z);
        transform.position = newPosition;
    }

    void RollDice() {
        int roll = Random.Range(1, 10);
        dice.text = roll.ToString();
        int newIndex = spaces.getSpaceIndex(currentSpace) + roll;
        if (newIndex > spaces.numOfSpaces - 1) {
            newIndex = newIndex - (spaces.numOfSpaces - 1);
            if (newIndex == 0) {
                newIndex += 1;
            }
        }
        currentSpace = spaces.getSpace(newIndex);
        SpaceAction(newIndex);
        MoveToSpace(currentSpace);
        gameManager.nextPlayerTurn();
    }

    void SpaceAction(int index) {
        Color color = spaces.getSpaceColor(index);
        if (color == Color.blue){
            currency += 3;
        }
        if (color == Color.red) {
            currency -= 3;
            if (currency < 0) {
                currency = 0;
            }
        }
        if (color == Color.green) {
            //Debug.Log("Green");
        }
    }

    public int getCurrency() {
        return currency;
    }

    public string getPlayerName() {
        return playerName;
    }
}
