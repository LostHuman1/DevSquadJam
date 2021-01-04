using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    Vector2Int screen;

    private void Awake()
    {
        screen = new Vector2Int(Screen.width, Screen.height);
    }


    void Update()
    {
        Vector3 mp = Input.mousePosition;
        bool mouseValid = (mp.x <= screen.x * 1.05f && mp.x >= screen.x * -0.05f);
        if (!mouseValid)
            return;
        if (mp.x > screen.x * 0.95f)
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
        }
        else if (mp.x < screen.x * 0.05f)
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed * 1.7f);
        }
    }
}
