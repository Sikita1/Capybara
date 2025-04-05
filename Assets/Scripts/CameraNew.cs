using UnityEngine;

public class CameraNew : MonoBehaviour
{
    private int _width = 1080;
    private int _height = 1920;

    private float _aspectRatio => _width / _height;
    private float _targetAspectRatio;

    private void Awake()
    {
        Screen.SetResolution(_width, _height, true);
    }

    private void Start()
    {
        _targetAspectRatio = _aspectRatio;
        float currentAspectRatio = _width / _height;

        float scaleFactor = currentAspectRatio / _targetAspectRatio;

        Camera.main.orthographicSize *= scaleFactor;
    }
    private void Update()
    {
        float currentAspectRatio = _width / _height;

        float scaleFactor = currentAspectRatio / _targetAspectRatio;

        Camera.main.orthographicSize *= scaleFactor;
    }
}
