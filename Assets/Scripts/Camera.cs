using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //public Transform camPivot;
    //float heading= 0;
    //Vector2 input;

    public Transform PlayerTransform;
    private Vector3 camOffset;

    [Range(0.01f, 1f)]
    public float smoothFactor = 0.5f;

    private void Start()
    {
        camOffset = transform.position - PlayerTransform.position;
    }

    private void Update()
    {
        Vector3 newPos = PlayerTransform.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        //heading +=  Input.GetAxis("Mouse X")* Time.deltaTime*180;
        //camPivot.rotation = Quaternion.Euler(0, heading, 0);
        //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //input = Vector2.ClampMagnitude(input, 1);
        //transform.position += new Vector3(input.x, 0, input.y) * Time.deltaTime * 5;
    } 

}
