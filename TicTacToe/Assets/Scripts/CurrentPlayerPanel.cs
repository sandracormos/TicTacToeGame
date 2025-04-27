using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentPlayerPanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI label;

    private void OnEnable()
    {
        TicTacToeManager.OnPlayerTurnSwitched += TicTacToeManager_OnPlayerTurnSwitched;
        TicTacToeManager.OnGameReseted += TicTacToeManager_OnGameReseted;
    }

    private void TicTacToeManager_OnGameReseted(object sender, System.EventArgs e)
    {
        label?.SetText($"Current Player: {TicTacToeManager.Instance.PlayerTurn}");
    }

    private void TicTacToeManager_OnPlayerTurnSwitched(CellValue cellValue)
    {
        label?.SetText($"Current Player: {cellValue}");
    }

    private void OnDisable()
    {
        TicTacToeManager.OnPlayerTurnSwitched -= TicTacToeManager_OnPlayerTurnSwitched;

        TicTacToeManager.OnGameReseted -= TicTacToeManager_OnGameReseted;
    }
}
