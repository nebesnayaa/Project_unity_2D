﻿using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]
    private Transform rotAnchor;

    void Start()
    {
        
    }

    void Update()
    {
        float dy = Input.GetAxis("Vertical");
        float angle = this.transform.eulerAngles.z;
        //if(angle > 180)
        //{
        //    angle -= 360;
        //}
        //if(-15 < angle + dy && angle + dy < 60)
        //{
        //    this.transform.RotateAround(rotAnchor.position, Vector3.forward, dy);
        //}

        if (angle > 180)
        {
            angle -= 360;
        }
        if (-50 < angle + dy && angle + dy < 30)
        {
            this.transform.RotateAround(rotAnchor.position, Vector3.forward, dy);
        }
    }
}
