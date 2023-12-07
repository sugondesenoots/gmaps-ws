using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        return Mathf.Sqrt((p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y));
        // Apply pythagoras theorem to find distance 
        // Mathf.Sqrt(a * a - b * b) 
        // For distance, finalpos.x - initialpos.x, etc.
    }  
}

