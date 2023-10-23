using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Image _button;
    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;

    public event UnityAction SwitchOn;
    public event UnityAction SwitchOff;

    public bool IsOnMusic { get; private set; }
     
    private void Awake()
    {
        TurnOn();
    }

    public void Toggle()
    {
        if (IsOnMusic)
        {
            TurnOff();
            SwitchOff?.Invoke();
        }
        else
        {
            TurnOn();
            SwitchOn?.Invoke();
        }
    }

    private bool TurnOn()
    {
        _button.sprite = _on;
        return IsOnMusic = true;
    }

    private bool TurnOff()
    {
        _button.sprite = _off;
        return IsOnMusic = false;
    }
}
