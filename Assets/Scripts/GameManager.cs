using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Public variables

    public static GameManager instance;
    public bool gameOver = false;
    public string gameWinner = "";

    [HideInInspector]
    public int playerTurn;

    [Header("Images")]
    [SerializeField] Sprite x;
    [SerializeField] Sprite o;

    // Private variables

    private string[,] gameBoard = { { "-", "-", "-" },
                                    { "-", "-", "-" },
                                    { "-", "-", "-" },};

    public enum SpriteType
    {
        X,
        O
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerTurn = 1;
    }

    private void Update()
    {
        CheckGameState();
    }

    private void CheckGameState()
    {
        // X win scenarios
        if (   (gameBoard[0, 0] == "X" && gameBoard[0, 1] == "X" && gameBoard[0, 2] == "X")
            || (gameBoard[1, 0] == "X" && gameBoard[1, 1] == "X" && gameBoard[1, 2] == "X")
            || (gameBoard[2, 0] == "X" && gameBoard[2, 1] == "X" && gameBoard[2, 2] == "X")
            || (gameBoard[0, 0] == "X" && gameBoard[1, 0] == "X" && gameBoard[2, 0] == "X")
            || (gameBoard[0, 1] == "X" && gameBoard[1, 1] == "X" && gameBoard[2, 1] == "X")
            || (gameBoard[0, 2] == "X" && gameBoard[1, 2] == "X" && gameBoard[2, 2] == "X")
            || (gameBoard[0, 0] == "X" && gameBoard[1, 1] == "X" && gameBoard[2, 2] == "X")
            || (gameBoard[0, 2] == "X" && gameBoard[1, 1] == "X" && gameBoard[2, 0] == "X"))
        {
            gameWinner = "X";
            gameOver = true;
        }
        // O win scenarios
        else if ((gameBoard[0, 0] == "O" && gameBoard[0, 1] == "O" && gameBoard[0, 2] == "O")
            || (gameBoard[1, 0] == "O" && gameBoard[1, 1] == "O" && gameBoard[1, 2] == "O")
            || (gameBoard[2, 0] == "O" && gameBoard[2, 1] == "O" && gameBoard[2, 2] == "O")
            || (gameBoard[0, 0] == "O" && gameBoard[1, 0] == "O" && gameBoard[2, 0] == "O")
            || (gameBoard[0, 1] == "O" && gameBoard[1, 1] == "O" && gameBoard[2, 1] == "O")
            || (gameBoard[0, 2] == "O" && gameBoard[1, 2] == "O" && gameBoard[2, 2] == "O")
            || (gameBoard[0, 0] == "O" && gameBoard[1, 1] == "O" && gameBoard[2, 2] == "O")
            || (gameBoard[0, 2] == "O" && gameBoard[1, 1] == "O" && gameBoard[2, 0] == "O") )
        {
            gameWinner = "O";
            gameOver = true;
        }
        // Cat's game
        else if (gameBoard[0, 0] != "-" && gameBoard[0, 1] != "-" && gameBoard[0, 2] != "-"
                && gameBoard[1, 0] != "-" && gameBoard[1, 1] != "-" && gameBoard[1, 2] != "-"
                && gameBoard[2, 0] != "-" && gameBoard[2, 1] != "-" && gameBoard[2, 2] != "-")
        {
            gameWinner = "CAT";
            gameOver = true;
        }
    }

    public void SetGameBoard(int row, int column, string symbol)
    {
        gameBoard[row, column] = symbol;
    }

    public Sprite GetSprite(SpriteType spriteType)
    {
        if (spriteType == SpriteType.X)
        {
            return x;
        }
        else if (spriteType == SpriteType.O)
        {
            return o;
        }
        else
        {
            Debug.Log("Error: Could not find a sprite type to return");
            return null;
        }
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
