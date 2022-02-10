using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    List<List<Cell>> cell;
    List<List<float>> testMatrix = new List<List<float>>();
    Cell.Status currentTurn = Cell.Status.circle;

    public delegate void OnGridUpdate();
    public OnGridUpdate onGridUpdate;

    public delegate void OnCellCreated(Cell cell);
    public OnCellCreated onCellCreated;
    //testMatr
    public TicTacToeGrid(int row, int col) : base(row, col)
    {
        cell = new List<List<Cell>>();
    }
    public TicTacToeGrid(int[,] arr) : base(arr)
    {

    }
    public void InitializeCells()
    {
        for (int i = 0; i < numOfRows; i++)
        {
            cell.Add(new List<Cell>());
            for (int j = 0; j < numOfCols; j++)
            {
                Cell tempCell = new Cell(i, j);
                tempCell.onStatusSetRequest += CellStatusSetRequest;
                cell[i].Add(tempCell);
                onCellCreated?.Invoke(cell[i][j]);
                
            }
        }
    }
    public void CellStatusSetRequest(int row, int col)
    {
        
        if (GetElement(row,col)==0 && !CheckWin())
        {
            ChangeTurn();
            SetElement(row, col, (int)currentTurn);
            cell[row][col].setStatus(currentTurn);
            
        }
        if (CheckWin())
        {
            Debug.LogError(currentTurn+ "  Won the game "); 
        }
    }
    public void ChangeTurn()
    {
        
        if (currentTurn == Cell.Status.circle)
        {
            this.currentTurn = Cell.Status.cross;
            //Debug.Log("Turn Change to cross");
        }
        else if (currentTurn == Cell.Status.cross)
        {
            this.currentTurn = Cell.Status.circle;
            //Debug.Log("Turn Change to circle");
        }
    }
    public bool CheckWin()
    {
        bool win = false;
        if (RowWin()||ColWin()||DiognalWin()|| InversDiognalWin())
        {
            win = true;
        }
        return win;
    }
    //public void setCellStatus(int row,int col,Cell.Status status)
    //{
    //    Debug.Log("Cell Status Update");
    //    SetElement(row, col, (int)status);
    //}
    //public void setStatusToAllElement(Cell.Status status)
    //{
    //    setMatrix((int)status);
    //}

    public override void OnMatrixUpdate()
    {
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCols; j++)
            {
                cell[i][j].statusUpdate((Cell.Status)GetElement(i, j));
            }
        }
    }
    public bool RowWin()
    {
        for (int i = 0; i < numOfRows; i++)
        {
            if (GetElement(i, 0) != 0f)
            {
                if (isRowSame(i))
                {
                    return true;
                }
            }
            
        }
        return false;
    }
    public bool ColWin()
    {
        for (int i = 0; i < numOfRows; i++)
        {
            if (GetElement(0, i) != 0f)
            {
                if (isColSame(i))
                {
                    return true;
                }
            }

        }
        return false;
    }
    public bool DiognalWin()
    {
        if (GetElement(0, 0) != 0f)
        {
            if (isDiagonal())
            {
                return true;
            }
        }
        return false;
    }
    public bool InversDiognalWin()
    {
        if (GetElement(0,numOfCols-1) != 0f)
        {
            if (isInversDiognal())
            {
                return true;
            }
        }
        return false;
    }
}
