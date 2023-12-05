using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    float Magnitude(Vector3 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z); 
    }
        
    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        vector.x /= mag;
        vector.y /= mag;
        vector.z /= mag; 
        return vector;
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z); 
    }

    float AngleToPlayer()
    {
        Vector3 A = OtherPlayer.transform.position; 
        Vector3 B = transform.position;

        Vector3 vectorAB = A - B;

        A = Normalise(A);
        B = Normalise(B);
        
        float angle = Mathf.Acos(Dot(transform.forward, Normalise(vectorAB))) * Mathf.Rad2Deg;
        
        DebugExtension.DebugArrow(transform.position, vectorAB, Color.black); 
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);  

        return angle;
    }

    void Update()
    {
        if (IsCaptain)
        {
            float angle = AngleToPlayer();
            Debug.Log(angle);
        }
    }
}
