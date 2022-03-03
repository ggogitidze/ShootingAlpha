using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
     private Vector3 target;
    public GameObject crosshair;
    public GameObject gun;

    //gets position of crosshair on camera and gets called in PointAndShoot.cs(ShootOnAim() method)
    public void crosshairMove(){
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            crosshair.transform.position = new Vector3(target.x,target.y);
    }

    //returns: target
    public Vector3 cameraPosition()
    {
        return target;
    }
}
