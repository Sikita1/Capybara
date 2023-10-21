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

    public void OnIdle()
    {
        EnableStatus("Idle", "StartOn", "StartOff", "Hidden");

        //_animator.SetBool("Idle", true);
        //_animator.SetBool("StartOn", false);
        //_animator.SetBool("StartOff", false);
        //_animator.SetBool("Hidden", false);
    }
    public void OnHidden()
    {
        EnableStatus("Hidden", "Idle", "StartOn", "StartOff");

        //_animator.SetBool("Hidden", true);
        //_animator.SetBool("Idle", false);
        //_animator.SetBool("StartOn", false);
        //_animator.SetBool("StartOff", false);
    }

    public void OnStartOn()
    {
        EnableStatus("StartOn", "Idle", "StartOff", "Hidden");

        //_animator.SetBool("StartOn", true);
        //_animator.SetBool("Idle", false);
        //_animator.SetBool("StartOff", false);
        //_animator.SetBool("Hidden", false);
    }
    public void OnStartOff()
    {
        EnableStatus("StartOff", "Idle", "StartOn", "Hidden");

        //_animator.SetBool("StartOff", true);
        //_animator.SetBool("Idle", false);
        //_animator.SetBool("StartOn", false);
        //_animator.SetBool("Hidden", false);
    }

    private void EnableStatus(string enbled, string dis1, string dis2, string dis3)
    {
        _animator.SetBool(enbled, true);
        _animator.SetBool(dis1, false);
        _animator.SetBool(dis2, false);
        _animator.SetBool(dis3, false);
    }
}
