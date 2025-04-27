using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerPanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI label;

    private void OnEnable()
    {
        TicTacToeManager.OnGameOver += TicTacToeManager_OnGameOver;
        TicTacToeManager.OnGameReseted += TicTacToeManager_OnGameReseted;
        TicTacToeManager.OnDraw += TicTacToeManager_OnDraw;
    }

    private void TicTacToeManager_OnDraw(object sender, System.EventArgs e)
    {
        label?.SetText($"It's a DRAW");
    }

    private void TicTacToeManager_OnGameReseted(object sender, System.EventArgs e)
    {
        label?.SetText(string.Empty);
    }

    private void OnDisable()
    {
        TicTacToeManager.OnGameOver -= TicTacToeManager_OnGameOver;
        TicTacToeManager.OnGameReseted -= TicTacToeManager_OnGameReseted;
        TicTacToeManager.OnDraw -= TicTacToeManager_OnDraw;
    }

    private void TicTacToeManager_OnGameOver(CellValue cellValue)
    {
        label?.SetText($"{cellValue} WON");
    }
}
