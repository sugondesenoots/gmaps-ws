// Uncomment this whole file. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        SetIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++) // Do for each row
            for (int x = 0; x < 3; x++) // Do for each col
            {
                entries[y, x] = multiArray[y, x];
            }
    }

    public HMatrix2D(float m00, float m01, float m02,
                     float m10, float m11, float m12,
                     float m20, float m21, float m22)
    {
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(); 

        for (int y = 0; y < 3; y++) 
            for (int x = 0; x < 3; x++)
            {
                result.entries[y, x] = left.entries[y, x] + right.entries[y, x]; 
            }

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
            {
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
            {
                result.entries[y, x] = left.entries[y, x] * scalar;
            }

        return result;
    }

    // Note that the second argument is a HVector2D object 
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
             left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h,
             left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            //left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            //left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],

            // and so on for another 7 entries  

            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]

        // Changed format so my eyes don't suffer 
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.entries[y, x] != right.entries[y, x])
                    return false;
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.entries[y, x] == right.entries[y, x])
                    return false; 
        return true;
    }

    //    public HMatrix2D transpose()
    //    {
    //        return // your code here
    //    }

    //    public float GetDeterminant()
    //    {
    //        return // your code here
    //    }

    public void SetIdentity()
    {
        //for (int y = 0; y < 3; y++) // Do for each row
        //{
        //    for (int x = 0; x < 3; x++) // Do for each col
        //    {
        //        if (x == y)
        //        {
        //            entries[y, x] = 1; // 1's in Identity Matrix are when x and y are equal
        //        }
        //        else
        //        {
        //            entries[y, x] = 0; // Every other value is 0 
        //        }
        //    }
        //} 

        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                entries[y, x] = (x == y) ? 1:0; 
    }

    public void SetTranslationMat(float transX, float transY)
    {  
        SetIdentity();
        entries[0,2] = transX;
        entries[1,2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity(); 
        float rad = rotDeg * Mathf.Deg2Rad;
        entries[0,0] = Mathf.Cos(rad);
        entries[0,1] = -Mathf.Sin(rad);
        entries[1,0] = Mathf.Sin(rad);
        entries[1,1] = Mathf.Cos(rad);
    }

    //public void SetScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
