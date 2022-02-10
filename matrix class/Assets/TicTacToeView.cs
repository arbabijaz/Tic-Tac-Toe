using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeView : MonoBehaviour
{
    TicTacToeGrid ticTacToeGrid;
    public GameObject cellPrefab;
    public int row;
    public int col;
    public float horizontalSpac;
    public float verticalSpace;
    int counter = 0;
    List<GameObject> cells=new List<GameObject>();
    private void Start()
    {
        InitializeGrid();
    }
    public void InitializeGrid()
    {
        ticTacToeGrid = new TicTacToeGrid(row,col);
        ticTacToeGrid.onCellCreated += cellCreated;
        ticTacToeGrid.InitializeCells();
    }
    private void cellCreated(Cell cell)
    {
        InstentiatePosition();
        GameObject cellView = Instantiate(cellPrefab, new Vector3(horizontalSpac,0,verticalSpace),transform.rotation);
        counter++;
        cellView.GetComponent<CellView>().setCell(cell);
        cells.Add(cellView);
    }
    void InstentiatePosition()
    {
        if (counter == row)
        {
            verticalSpace += 1.5f;
            counter = 0;
            horizontalSpac = 3.5f;
        }
        else
        {
            horizontalSpac += 1.5f;
        }
    }
}
