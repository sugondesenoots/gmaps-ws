// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.SetIdentity();
        mat.Print();
        Question2();
    } 
     
    void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(1f, 2f, 1f, 0f, 1f, 0f, 2f, 3f, 4f);  

        HMatrix2D mat2 = new HMatrix2D(2f, 5f, 0f, 6f, 7f, 0f, 1f, 8f, 0f);    

        HMatrix2D resultMat = new HMatrix2D();
        HVector2D vec1 = new HVector2D();

        resultMat = mat1 * mat2;
        resultMat.Print();
    }
}  
 
 

