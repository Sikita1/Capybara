using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string Idle = "Idle";
    private const string Dance = "Dance";
    private const string Expectation = "Expectation";
    private const string Run = "Run";

    [SerializeField] private CatWin _cat;
    [SerializeField] private CatWin _cat2;

    [SerializeField] private Buttons _buttonMenu;

    [SerializeField] private AudioSource _audioWin;
    [SerializeField] private AudioSource _audioGame;

    [SerializeField] private MusicController _musicController;

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
        _cat.gameObject.SetActive(false);
        _cat2.gameObject.SetActive(false);
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

        Enemy[] deceased = GameObject.FindObjectsOfType<Enemy>();

        for (int i = 0; i < deceased.Length; i++)
            deceased[i].Die();
    }

    public void PlayerReady()
    {
        Alive();
        Inactivity();
        AudioPlay(_audioGame);
    }

    public void PlayerWaiting()
    {
        _animation.SetBool(Idle, false);
    }

    public void StopDance()
    {
        _animation.SetBool(Dance, false);
        _animation.SetBool(Expectation, true);
        _cat.gameObject.SetActive(false);
        _cat2.gameObject.SetActive(false);
        transform.position = new Vector3(_positionRelax,
                                         transform.position.y,
                                         transform.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.x,
                                              0,
                                              transform.rotation.z);
        AudioStop(_audioWin);
    }

    public void Defeated()
    {
        Dead();
        StartDancing();
        _buttonMenu.OnStartOn();
        AudioStop(_audioGame);
    }

    public void StartRunning()
    {
        PlayerWaiting();
        _animation.SetBool(Run, true);
    }

    public void Inactivity()
    {
        _animation.SetBool(Idle, true);
        _animation.SetBool(Run, false);
    }

    private void StartDancing()
    {
        DanceCats();
        PlayerWaiting();
        _animation.SetBool(Dance, true);

        transform.position = new Vector3(0,
                                         transform.position.y,
                                         transform.position.z);

        AudioPlay(_audioWin);
    }

    private void DanceCats()
    {
        _cat.gameObject.SetActive(true);
        _cat2.gameObject.SetActive(true);
    }

    private void AudioPlay(AudioSource audio)
    {
        if(_musicController.IsOnMusic)
            audio.Play();
    }

    private void AudioStop(AudioSource audio) =>
        audio.Stop();
}
