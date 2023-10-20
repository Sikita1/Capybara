using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Buttons : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnStartOn() => _animator.SetTrigger("StartOn");
    public void OnIdle() => _animator.SetTrigger("Idle");
    public void OnStartOff() => _animator.SetTrigger("StartOff");
    public void OnHidden() => _animator.SetTrigger("Hidden");
}
