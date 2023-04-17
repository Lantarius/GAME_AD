using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject TargetObject;
    Camera Camera;
    Vector3 CurrentPos;
    Vector3 StartPos;
    float XMax; //Mаксимальная допустимая координата по Х
    private void Start()
    {
        Camera = Camera.main;
        XMax = 19;
        StartPos = new Vector3(2, 5.5f, -7);
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            StartPos = new Vector3(1, 6, -9);
            XMax = 23;
        }
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            StartPos = new Vector3(2, 5.5f, -7);
            XMax = 19;
        }
        CurrentPos = StartPos;

    }
    private void FixedUpdate()
    {
        CurrentPos.x = StartPos.x + TargetObject.transform.position.x;
        CurrentPos.x = Mathf.Clamp(CurrentPos.x, 0, XMax);
        transform.position = CurrentPos;
    }
}
