using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraFlight : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMenuPl() => _animator.SetTrigger("MenuPl");
    public void OnGamePl() => _animator.SetTrigger("GamePl");
    public void OnStateGamePl() => _animator.SetTrigger("StateGamePl");
    public void OnStateMenuPl() => _animator.SetTrigger("StateMenuPl");
}
