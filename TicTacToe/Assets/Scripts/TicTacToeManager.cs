using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TicTacToeManager : MonoBehaviour
{
    private static TicTacToeManager instance;
    public static TicTacToeManager Instance { get => instance; private set { instance = value; } }

    public static event EventHandler OnGameStarted;
    public static event EventHandler OnGameReseted;
    public static event EventHandler OnDraw;

    public delegate void CellValueDelegate(CellValue cellValue);
    public static event CellValueDelegate OnGameOver;
    public static event CellValueDelegate OnPlayerTurnSwitched;

    [Header("References")]
    [SerializeField]
    List<CellButton> cellButtons = new();

    public List<CellButton> CellButtons { get => cellButtons; }

    [field:SerializeField]
    public CellValue PlayerTurn { get; private set; } = CellValue.X;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnGameStarted?.Invoke(this, EventArgs.Empty);
        OnPlayerTurnSwitched?.Invoke(PlayerTurn);
    }

    public void OnCellButtonPress( CellButton cellButton)
    {
        CheckWinCondition();

        if (PlayerTurn == CellValue.X)
            PlayerTurn = CellValue.Zero;
        else
            PlayerTurn = CellValue.X;

        OnPlayerTurnSwitched?.Invoke(PlayerTurn);
    }

    public void CheckWinCondition()
    {
      
        if (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
          
            CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
        
            CheckLine(0, 4, 8) || CheckLine(2, 4, 6))
        {
            OnGameOver?.Invoke(PlayerTurn == CellValue.X ? CellValue.X : CellValue.Zero);
        }
        else if (IsBoardFull())
        {
            OnDraw?.Invoke(this, EventArgs.Empty);
        }
    }

    private bool CheckLine(int indexA, int indexB, int indexC)
    {
        var a = cellButtons[indexA];
        var b = cellButtons[indexB];
        var c = cellButtons[indexC];

        if (a.CellValue == CellValue.None)
            return false;

        return a.CellValue == b.CellValue && b.CellValue == c.CellValue;
    }

    public bool IsBoardFull()
    {
        foreach (var cell in cellButtons)
        {
            if (cell.CellValue == CellValue.None)
                return false;
        }
        return true;
    }

    public void ResetGame()
    {
        PlayerTurn = CellValue.X;
        OnGameReseted?.Invoke(this, EventArgs.Empty);
    }
}
