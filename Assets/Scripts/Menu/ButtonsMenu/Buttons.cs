using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Buttons : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnIdle() =>
        EnableStatus("Idle", "StartOn", "StartOff", "Hidden");

    public void OnHidden() =>
        EnableStatus("Hidden", "Idle", "StartOn", "StartOff");

    public void OnStartOn() =>
        EnableStatus("StartOn", "Idle", "StartOff", "Hidden");

    public void OnStartOff() =>
        EnableStatus("StartOff", "Idle", "StartOn", "Hidden");

    private void EnableStatus(string enbled, string dis1, string dis2, string dis3)
    {
        _animator.SetBool(enbled, true);
        _animator.SetBool(dis1, false);
        _animator.SetBool(dis2, false);
        _animator.SetBool(dis3, false);
    }
}
