using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public int row;
    public int col;
    public Status status;

    public delegate void StatusUpdate(Status status);
    public StatusUpdate statusUpdate;

    public delegate void OnStatusSetRequest(int row,int col);
    public OnStatusSetRequest onStatusSetRequest;


    public enum Status{none,cross,circle,win,loose };
    public Cell()
    {
        status = Status.win;
        row = 0;
        col = 0;
    }
    public Cell(int row,int col)
    {
        status = Status.none;
        this.row = row;
        this.col = col;
    }
    //public Cell(int row, int col,Status status)
    //{
    //    this.status = status;
    //    this.row = row;
    //    this.col = col;
    //}
    //public void unityCellStatus(Status status)
    //{
    //    statusUpdate?.Invoke(status);
    //}
    public void cellInteraction()
    {
        onStatusSetRequest?.Invoke(row, col);
        //Debug.Log("Cell Intrection");
    }
    public void setStatus(Status state)
    {
        this.status = state;
        statusUpdate?.Invoke(state);
    }
    public Status getStatus()
    {
        return status;
    }
    public void setRow(int row)
    {
        this.row = row;
    }
    public int getRow()
    {
        return row;
    }
    public void setcol(int col)
    {
        this.col = col;
    }
    public int getCol()
    {
        return col;
    }
}
