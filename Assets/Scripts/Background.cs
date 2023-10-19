using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;
    [SerializeField] private Image _image;

    private void Start()
    {
        GetRundomNumber();
        SetRandomImage();
    }

    private int GetRundomNumber() => Random.Range(0, _images.Length);

    private void SetRandomImage() => _image.sprite = _images[GetRundomNumber()];
}
