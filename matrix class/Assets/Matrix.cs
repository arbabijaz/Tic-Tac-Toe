using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix :MonoBehaviour
{ 
    protected int numOfRows;
    protected int numOfCols;
    List<List<float>> matrixx;
    string resMatrix;
    List<float> listt;


    public Matrix(int row, int col)
    {
        numOfRows = row;
        numOfCols = col;
        InitializeMatrix();
        for (int i = 0; i < row; i++)
        {
            listt = new List<float>();
            for (int j = 0; j < col; j++)
            {
                listt.Add(0);
            }
            matrixx.Add(listt);
        }
        
    }
    public Matrix()
    {
        InitializeMatrix();
    }
    void InitializeMatrix()
    {
        matrixx=new List<List<float>>();
    }
    public Matrix(int [,] arr)
    {
        numOfRows = arr.Length;
        numOfCols = arr.Length;
        InitializeMatrix();
        for (int i = 0; i < arr.Length; i++)
        {
            listt = new List<float>();
            for (int j = 0; j < arr.Length; j++)
            {
                listt.Add(arr[i,j]);
            }
            matrixx.Add(listt);
        }
       
    }
    public void SetElement(int row, int col, int val)
    {
        matrixx[row][col] = val;
    }
    public float GetElement(int row, int cal)
    {
        float val;
        val = matrixx[row][cal];
        return val;
    }
    public void SetRow(int row, int[] arr)
    {
        for (int i = 0; i < matrixx.Count; i++)
        {
            matrixx[row][i] = arr[i];
        }
    }
    public void setRowNum(int row, int num)
    {
        for (int i = 0; i < matrixx.Count; i++)
        {
            matrixx[row][i] = num;
        }
    }
    public void setCol(int col, int[] arr)
    {
        for (int i = 0; i < matrixx.Count; i++)
        {
            matrixx[i][col] = arr[i];      
        }
    }
    public void setColNum(int col,int num)
    {
        for (int i = 0; i < matrixx.Count; i++)
        {
            matrixx[i][col] = num;
        }
    }
    public void SwapRos(int row1,int row2)
    {
        listt = new List<float>();
        List<float> list2 = new List<float>();
        
        for (int i = 0; i < matrixx.Count; i++)
        {
            
            listt.Add(matrixx[row1][i]);
            list2.Add(matrixx[row2][i]);
        }
        matrixx[row1] = list2;
        matrixx[row2] = listt;
    }
    public void swapCol(int col1, int col2)
    {
        listt = new List<float>();
        List<float> list2 = new List<float>();
        for (int i = 0; i < matrixx.Count; i++)
        {
            listt.Add( matrixx[i][col1]);
            list2.Add(matrixx[i][col2]);
        }
        for (int i = 0; i < matrixx.Count; i++)
        {
            matrixx[i][col1] = list2[i];
            matrixx[i][col2] = listt[i];
        }
    }
    public void setMatrix(int num)
    {
        for(int i=0; i < matrixx.Count; i++)
        {
            for (int j = 0; j < matrixx[i].Count; j++)
            {
                matrixx[i][j] = num;
            }
        }
    } // 2d List total lenght issue
    public float[] getRow(int rowNum)
    {
        float[] arr=new float[matrixx.Count];
        for (int i = 0; i < matrixx.Count; i++)
        {
            arr[i]=matrixx[rowNum][i];
        }
        return arr;
    } // Array lenght issue
    public float[] getCol(int colNum)
    {
        float[] arr = new float[matrixx.Count];
        for (int i = 0; i < matrixx.Count; i++)
        {
            arr[i] = matrixx[i][colNum];
        }
        return arr;
    }
    public bool isRowSame(int rowNum)
    {
        bool sameRow = false;
        for (int i = 0; i < matrixx.Count-1; i++)
        {
            if(matrixx[rowNum][i] == matrixx[rowNum][i + 1])
            {
                sameRow = true;
            }
            else
            {
                return false;
            }
        }
        return sameRow;
    }
    public bool isColSame(int colNum)
    {
        bool sameCal = false;
        for (int i = 0; i < matrixx.Count-1; i++)
        {
            if (matrixx[i][colNum] == matrixx[i + 1][colNum])
            {
                sameCal = true;
            }
            else
                sameCal = false;
        }
        return sameCal;
    }
    public List<List<float>> addMatrix(List<List<float>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            listt = new List<float>();
            for (int j = 0; j < matrix.Count; j++)
            {
                listt.Add(matrixx[i][j]+matrix[i][j]);
            }
            matrixx.Add(listt);
        }
        return matrixx;
    }
    public List<List<float>> subMatrix(List<List<float>> matrix)
    {
        List<List<float>> matrixx=new List<List<float>>() ;
        for (int i = 0; i < matrix.Count; i++)
        {
            listt = new List<float>();
            for (int j = 0; j < matrix.Count; j++)
            {
                listt.Add(matrixx[i][j] - matrix[i][j]);
            }
            matrixx.Add(listt);
        }
       
        return matrixx;
    }
    public float addListMultipul(List<float> list1, List<float> list2)
    {
        float res = 0;
        for (int i = 0; i < list1.Count; i++)
        {
            res += list1[i] * list2[i];
        }
        return res;
    }
    public List<List<float>> matrixMultiply(List<List<float>> matrix)
    {
        List<List<float>> resultmatrix = new List<List<float>>();
        for (int i = 0; i < matrix.Count; i++)
        {
            listt = new List<float>();
            List<float> list1 = new List<float>();
            List<float> list2 = new List<float>();
            for (int j = 0; j < matrix.Count; j++)
            {
                list1.Add(matrixx[i][j]);
                rowColMultiply(matrix, list1, list2, j);
                resultmatrix.Add(listt);

                //listt.Add(addListMultipul(,;
            }
        }
        return resultmatrix;
    }

    private void rowColMultiply(List<List<float>> matrix, List<float> list1, List<float> list2, int j)
    {
        for (int k = 0; k < matrix.Count; k++)
        {
            list2.Add(matrix[k][j]);
            listt.Add(addListMultipul(list1, list2));

        }
    } //helping function for multiply
    public void setDiagonal(int num)
    {
        for (int i = 0; i < matrixx.Count; i++)
        {
            matrixx[i][i] = num;
        }
    }
    public bool isDiagonal()
    {
        bool diagonal = false; 
        
        for (int i = 0; i < matrixx.Count-1; i++)
        {
            if(matrixx[i][i]== matrixx[i + 1][i + 1])
            {
                diagonal = true;
            }
            else
            {
                return false;
            }
        }
        
        return diagonal;
    }
    public bool isInversDiognal()
    {
        bool inversDiognal = false;
        int temp = numOfCols-1;
        for (int i = 0; i < numOfRows-1; i++)
        {
            if(matrixx[i][temp]== matrixx[i + 1][temp - 1])
            {
                inversDiognal = true;
            }
            else
            {
                return false;
            }
            temp--;
            
        }
        return inversDiognal;
    }

    public void printMatrix()
    {
        for (int i = 0; i < matrixx.Count; i++)
        {
            for (int j = 0; j < matrixx[0].Count; j++)
            {
                resMatrix += matrixx[i][j];
            }
            resMatrix += '\n';
        }
        Debug.Log(resMatrix);
    }
    virtual public void OnMatrixUpdate()
    {

    }
   
}
