﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public Transform target;
    float speed = 10;
    Vector3[] path;
    int targetIndex;
    int unitSize;
    //public GameObject mainChannel; //Waleed
   // List<unit> allOtherUnits; //Waleed

    void Awake() { //Waleed
      
    }

    void Start() {
        //  allOtherUnits = mainChannel.getallUnits();
        //Debug.Log(name + " got the communicator and array of others with first element as " + allOtherUnits[0].name); //Waleed
        GameObject comm = GameObject.Find("Communicator");
        Communicator communi = comm.GetComponent<Communicator>();
        unitSize = communi.myUnits.Length;
        Debug.Log("The number of units in communicator is  " + unitSize.ToString()); //Waleed


        PathRequestManager.RequestPath(transform.position, target.position,OnPathFound);
    }

    void Update() { 
        
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful) {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
         }
    }


    IEnumerator FollowPath() {
        targetIndex = 0;
        Vector3 currentWaypoint = path[0];

        while (true) {
            if (transform.position == currentWaypoint) {
                targetIndex++;
                print("TargetIndex is: " + targetIndex + ".");
                if (targetIndex >= path.Length) {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed *Time.deltaTime);
            yield return null;
        }
    
    }

    public void Waleed() {
    
    }
    
    public void Alaa(){

    }

    public void OnDrawGizmos() {
        /*
        if (path != null) {
            for (int i = targetIndex; i <= path.Length; i++)
            {
                Gizmos.color = Color.black;
                //Gizmos.DrawCube(path[i],Vector3.one);
                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }*/
    
    }
}
