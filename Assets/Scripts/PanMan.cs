using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMan : MonoBehaviour
{

    public Transform target;
    public Transform pivotObject;
    // public Vector3 pivotPoint = new Vector3(0f,0f,0f);
    public float rotationAngle = 90f;

    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, Vector3.up, rotationAngle * Time.deltaTime);

        // transform.position += new Vector3(0.0f, 0.0f, 4.0f);
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        // transform.LookAt(target, Vector3.left);
    }
}
