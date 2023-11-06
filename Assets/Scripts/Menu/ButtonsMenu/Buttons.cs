using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnIdle()
    {
        EnableStatus("Idle", "StartOn", "StartOff", "Hidden");
        ButtonInteractable(true);
    }

    public void OnHidden()
    {
        EnableStatus("Hidden", "Idle", "StartOn", "StartOff");
        ButtonInteractable(false);
    }

    public void OnStartOn()
    {
        EnableStatus("StartOn", "Idle", "StartOff", "Hidden");
        ButtonInteractable(false);
    }

    public void OnStartOff()
    {
        EnableStatus("StartOff", "Idle", "StartOn", "Hidden");
        ButtonInteractable(false);
    }
    private void EnableStatus(string enbled, string dis1, string dis2, string dis3)
    {
        _animator.SetBool(enbled, true);
        _animator.SetBool(dis1, false);
        _animator.SetBool(dis2, false);
        _animator.SetBool(dis3, false);
    }

    private void ButtonInteractable(bool activ) =>
        _button.interactable = activ;
}
