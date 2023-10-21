using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private CatWin _cat;

    [SerializeField] private Buttons _buttonMenu;

    public event UnityAction StateAlive;
    public event UnityAction StateDead;

    private Animator _animation;
    private float _positionRelax = -2.18f;

    public bool Lose { get; private set; }

    private void Awake()
    {
        _animation = GetComponent<Animator>();
    }

    private void Start()
    {
        //Alive();
        _cat.gameObject.SetActive(false);
    }

    public void Alive()
    {
        Lose = false;
        StateAlive?.Invoke();
    }
    public void Dead()
    {
        Lose = true;
        StateDead?.Invoke();
    }

    public void PlayerReady()
    {
        PlayerWaiting();
        Alive();
    }

    public void PlayerWaiting()
    {
        _animation.SetBool("Idle", false);
    }

    public void StopDance()
    {
        _animation.SetBool("Dance", false);
        _animation.SetBool("Expectation", true);
        _cat.gameObject.SetActive(false);
        transform.position = new Vector3(_positionRelax,
                                         transform.position.y,
                                         transform.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.x,
                                              0,
                                              transform.rotation.z);
    }

    public void Defeated()
    {
        Dead();
        Dance();
        _buttonMenu.OnStartOn();
    }

    public void Run()
    {
        PlayerWaiting();
        _animation.SetBool("Run", true);
    }

    public void Idle()
    {
        _animation.SetBool("Idle", true);
        _animation.SetBool("Run", false);
    }

    private void Dance()
    {
        DanceCat();
        PlayerWaiting();
        _animation.SetBool("Dance", true);
    }

    private void DanceCat()
    {
        float zoneCat = 1.5f;
        float Left = -1.5f;
        float catPositionY = -2.86f;

        if (transform.position.x >= 1.1f)
            zoneCat = Left;

        _cat.transform.position = new Vector3(transform.position.x + zoneCat,
                                              catPositionY,
                                              transform.position.z);

        _cat.gameObject.SetActive(true);
    }
}
