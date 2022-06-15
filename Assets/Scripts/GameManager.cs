using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<Player> playerObjects = new List<Player>();
    public Player playerOne;
    public Player playerTwo;
    public Player playerThree;
    public Player playerFour;

    public Player currentPlayerTurn;
    public TextMeshProUGUI currentPlayerTurnUI;

    private int playerOneCurrency;
    private int playerTwoCurrency;
    private int playerThreeCurrency;
    private int playerFourCurrency;

    public TextMeshProUGUI playerOneUI;
    public TextMeshProUGUI playerTwoUI;
    public TextMeshProUGUI playerThreeUI;
    public TextMeshProUGUI playerFourUI;

    void Start() {
        playerObjects.Add(playerOne);
        playerObjects.Add(playerTwo);
        playerObjects.Add(playerThree);
        playerObjects.Add(playerFour);
        playerObjects = Fisher_Yates_Shuffle(playerObjects);
        setCurrentPlayerTurn(playerObjects[0]);
    }

    void FixedUpdate() {
        playerOneCurrency = playerOne.getCurrency();
        playerOneUI.text = "Coins: " + playerOneCurrency.ToString();

        playerTwoCurrency = playerTwo.getCurrency();
        playerTwoUI.text = "Coins: " + playerTwoCurrency.ToString();
    
        playerThreeCurrency = playerThree.getCurrency();
        playerThreeUI.text = "Coins: " + playerThreeCurrency.ToString();

        playerFourCurrency = playerFour.getCurrency();
        playerFourUI.text = "Coins: " + playerFourCurrency.ToString();
    }

    public Player getCurrentPlayerTurn() {
        return currentPlayerTurn;
    }

    public void setCurrentPlayerTurn(Player player) {
        currentPlayerTurn = player;
        currentPlayerTurnUI.text = currentPlayerTurn.getPlayerName() + "'s Turn";
    }

     public static List<Player> Fisher_Yates_Shuffle (List<Player>aList) {
 
         System.Random _random = new System.Random();
 
         Player myGO;
 
         int n = aList.Count;
         for (int i = 0; i < n; i++)
         {
             int r = i + (int)(_random.NextDouble() * (n - i));
             myGO = aList[r];
             aList[r] = aList[i];
             aList[i] = myGO;
         }
 
         return aList;
     }

    public void nextPlayerTurn() {
        int currentIndex = playerObjects.IndexOf(getCurrentPlayerTurn());
        switch(currentIndex){
            case 0:
                setCurrentPlayerTurn(playerObjects[currentIndex + 1]);
                break;
            case 1:
                setCurrentPlayerTurn(playerObjects[currentIndex + 1]);
                break;
            case 2:
                setCurrentPlayerTurn(playerObjects[currentIndex + 1]);
                break;
            case 3:
                setCurrentPlayerTurn(playerObjects[0]);
                break;
        }
    }
}
