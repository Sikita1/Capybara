using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNew : MonoBehaviour
{
    private float _aspectRatio = 1080 / 1920/*(float)Screen.width / (float)Screen.height*/;
    private float _targetAspectRatio;

    private void Awake()
    {
        Screen.SetResolution(1080, 1920,/*Screen.width, Screen.height,*/ true);
    }

    private void Start()
    {
        _targetAspectRatio = _aspectRatio; // используйте соотношение сторон, определенное в первом шаге
        float currentAspectRatio = 1080 / 1920/*(float)Screen.width / (float)Screen.height*/;

        float scaleFactor = currentAspectRatio / _targetAspectRatio;

        Camera.main.orthographicSize *= scaleFactor;
    }
    private void Update()
    {
        float currentAspectRatio = 1080 / 1920/*(float)Screen.width / (float)Screen.height*/;

        float scaleFactor = currentAspectRatio / _targetAspectRatio;

        Camera.main.orthographicSize *= scaleFactor;
    }
}
