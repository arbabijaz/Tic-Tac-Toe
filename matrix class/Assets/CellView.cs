using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView :MonoBehaviour
{
    Cell cell = new Cell();
    public GameObject[] cellState;
    

    void Start()
    {

        initializeUnityCell();
    }

    private void initializeUnityCell()
    {
        
       
    }
    void setStatus(Cell.Status status)
    {
        //Debug.Log("cell view");
        for (int i = 0; i < cellState.Length; i++)
        {
            if (i == (int)status)
            {
                cellState[i].SetActive(true);
            }
            else
            {
                cellState[i].SetActive(false);
            }
        }
    }
    public void setCell(Cell cell)
    {
        this.cell = cell;
    }
    public void setPosition(int horizontalSpac,int verticalSpace)
    {

    }
    

    private void OnMouseDown()
    {
        cell.statusUpdate += setStatus;
        //Debug.Log("mouse call");
        cell.cellInteraction();
    }
}
