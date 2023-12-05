using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray(); 
         
        //if (IsCaptain)
        //{
        //    FindMinimum();
        //}
    }

    //void FindMinimum()
    //{
    //    float minHeight = float.MaxValue;

    //    for (int i = 0; i < 10; i++)
    //    {
    //        float height = Random.Range(5f, 20f);
    //        Debug.Log(height);

    //        if (height < minHeight)
    //        {
    //            minHeight = height;
    //        }
    //    }

    //    Debug.Log("The minimum value is " + minHeight);
    //}


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

    float Dot(Vector3 b)
    {
        Vector3 a = transform.forward;
        return (a.x * b.x + a.y * b.y + a.z * b.z);
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f; 
         
        for (int i = 0; i < OtherPlayers.Length; i++)  
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            toPlayer = Normalise(toPlayer);

            float dot = Dot(toPlayer);  
            float angle = Mathf.Acos(dot); 
            angle = angle * Mathf.Rad2Deg; 
             
            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        return closest; 
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.black);
        }
    }

    void Update()
    {
        //DrawVectors();
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


