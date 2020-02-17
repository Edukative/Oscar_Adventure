using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWaypoint : MonoBehaviour
{
    public Transform target;
    int waypointIndex;
    Transform waypointsParent;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    private void OnDrawGizmos()
    {

        waypointIndex = transform.GetSiblingIndex();
        waypointsParent = transform.parent;
        
        if (waypointIndex >= waypointsParent.transform.childCount - 1)
        {
            target = waypointsParent.GetChild(0);
        }
        else
        {
            target = waypointsParent.GetChild(waypointIndex + 1);
        }
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, target.position);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.05f);

    }










}
