using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {

    public string playerName;

    [SerializeField]
    private int playerIndex = 0;

    public Color playerColor;

    private Vector2 inputVector = Vector2.zero;

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
    }

    void MoveToSpace(GameObject spaceToMove) {
        Vector3 newPosition = new Vector3(spaceToMove.transform.position.x, spaceToMove.transform.position.y + 1.5f, spaceToMove.transform.position.z);
        StartCoroutine(MoveTo(transform, newPosition, 1f));
    }

    IEnumerator MoveTo (Transform objectToMove, Vector3 targetPosition, float timeToTake) {
        float t = 0;
        Vector3 originalPosition = objectToMove.position;
        while (t < 1) {
            t += Time.deltaTime / timeToTake;
            objectToMove.position = Vector3.Lerp (originalPosition, targetPosition, t);
            yield return null;
        }
    }

    public void RollDice() {
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

    public void SetInputVector(Vector2 direction) {
        inputVector = direction;
    }

    public int getCurrency() {
        return currency;
    }

    public string getPlayerName() {
        return playerName;
    }

    public int GetPlayerIndex() {
        return playerIndex;
    }
}
