using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;
    [SerializeField] private Image _image;
    [SerializeField] private Image _imageFon;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GetRundomNumber();
        SetRandomImage();
        _imageFon.sprite = _image.sprite;
    }

    public void OnMenu() => _animator.SetTrigger("StateMenu");
    public void GameChange() => _animator.SetTrigger("Game");
    public void InPlay() => _animator.SetTrigger("StateGame");
    public void MenuNavigation() => _animator.SetTrigger("Menu");

    private int GetRundomNumber() => Random.Range(0, _images.Length);

    private void SetRandomImage()
    {
        _image.sprite = _images[GetRundomNumber()];
    }
}
