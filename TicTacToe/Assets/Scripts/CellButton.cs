using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CellValue
{
    None,
    X,
    Zero
}
public class CellButton : MonoBehaviour
{
    [field:SerializeField]
    public CellValue CellValue { get; private set; }

    [SerializeField]
    TextMeshProUGUI label;

    public void OnButtonPress()
    {
        if(CellValue != CellValue.None)
        {
            return;
        }
        CellValue = TicTacToeManager.Instance.PlayerTurn;
        label?.SetText(CellValue == CellValue.X ? "X" : "0");
        TicTacToeManager.Instance.OnCellButtonPress(this);
    }

    private void OnEnable()
    {
        TicTacToeManager.OnGameStarted += TicTacToeManager_OnGameStarted;
        TicTacToeManager.OnGameReseted += TicTacToeManager_OnGameReseted;
    }

 

    private void OnDisable()
    {
        TicTacToeManager.OnGameStarted -= TicTacToeManager_OnGameStarted;
        TicTacToeManager.OnGameReseted -= TicTacToeManager_OnGameReseted;
    }
    private void TicTacToeManager_OnGameStarted(object sender, System.EventArgs e)
    {
        label?.SetText(string.Empty);
        CellValue = CellValue.None;
    }
    private void TicTacToeManager_OnGameReseted(object sender, System.EventArgs e)
    {
        label?.SetText(string.Empty);
        CellValue = CellValue.None;
    }

    public void SetCellValue(CellValue value)
    {
        CellValue = value;
    }
}
