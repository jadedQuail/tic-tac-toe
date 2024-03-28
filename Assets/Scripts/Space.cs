using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Space : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image spaceImage;

    [Header("Space Data")]
    [SerializeField] int row;
    [SerializeField] int column;

    // Private variables
    GameManager gm;
    Color fullColor;

    private void Start()
    {
        gm = GameManager.instance;
        fullColor = new Color(spaceImage.color.r,
                              spaceImage.color.g,
                              spaceImage.color.b,
                              1);
    }

    // Function that gets called when this space is clicked
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!gm.gameOver)
        {
            // X's turn
            if (gm.playerTurn == 1)
            {
                spaceImage.color = fullColor;
                spaceImage.sprite = gm.GetSprite(GameManager.SpriteType.X);
                gm.playerTurn = 2;
                gm.SetGameBoard(row, column, "X");
            }
            // O's turn
            else
            {
                spaceImage.color = fullColor;
                spaceImage.sprite = gm.GetSprite(GameManager.SpriteType.O);
                gm.playerTurn = 1;
                gm.SetGameBoard(row, column, "O");
            }
        }
    }
}
