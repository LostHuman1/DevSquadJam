using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float xInput;
    private float zInput;
    private float xMouseInput;
    private float yMouseInput;

    public float moveSpeed;
    public float mouseSensitivity;
    public float upDownSpeed;

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        xMouseInput = Input.GetAxis("Mouse X");
        yMouseInput = Input.GetAxis("Mouse Y");

        transform.position += transform.forward * moveSpeed * Time.deltaTime * zInput;
        transform.position += transform.right * moveSpeed * Time.deltaTime * xInput;
        transform.Rotate(Vector3.up * xMouseInput * mouseSensitivity * Time.deltaTime);
        transform.Rotate(Vector3.right * yMouseInput * mouseSensitivity * Time.deltaTime);
    }
}