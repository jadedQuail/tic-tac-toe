using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_Text player1;
    [SerializeField] TMP_Text player2;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text statusText;

    [Header("Settings")]
    [SerializeField] Color activeTextColor;
    [SerializeField] Color inactiveTextColor;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerTurnText();
        HandleGameOver();
    }

    private void SetPlayerTurnText()
    {
        if (gm.playerTurn == 1)
        {
            player1.color = activeTextColor;
            player2.color = inactiveTextColor;
        }
        else if (gm.playerTurn == 2)
        {
            player1.color = inactiveTextColor;
            player2.color = activeTextColor;
        }
    }

    private void HandleGameOver()
    {
        if (gm.gameOver)
        {
            if (gm.gameWinner == "X")
            {
                statusText.text = "Player 1 Wins!";
            }
            else if (gm.gameWinner == "O")
            {
                statusText.text = "Player 2 Wins!";
            }
            else if (gm.gameWinner == "CAT")
            {
                statusText.text = "Cat's Game!";
            }

            gameOverPanel.SetActive(true);
        }
    }
}
