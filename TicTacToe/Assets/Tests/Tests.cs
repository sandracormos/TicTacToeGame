using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Tests
{   
    private TicTacToeManager manager;

    [SetUp]
    public void SetUp()
    {
        var gameObject = new GameObject();
        manager = gameObject.AddComponent<TicTacToeManager>();

        // Prepare cell buttons
        for (int i = 0; i < 9; i++)
        {
            var cellButton = new GameObject().AddComponent<CellButton>();            
            ((List<CellButton>)manager.GetType().GetField("cellButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(manager)).Add(cellButton);
        }
    }

    [Test]
    public void IsBoardFull_WhenAllCellsAreFull_ReturnsTrue()
    {
        manager.CellButtons.ForEach(c => c.SetCellValue(CellValue.X));
        Assert.IsTrue(manager.IsBoardFull());
    }

    [Test]
    public void IsBoardFull_WhenAtLeastOneCellIsEmpty_ReturnsFalse()
    {
        manager.CellButtons.ForEach(c => c.SetCellValue(CellValue.X));
        manager.CellButtons[0].SetCellValue(CellValue.None);
        Assert.IsFalse(manager.IsBoardFull());
    }
}
