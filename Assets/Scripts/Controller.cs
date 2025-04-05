using UnityEngine;
using YG;

[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Buttons _buttonStart;
    [SerializeField] private Buttons _buttonMenu;
    [SerializeField] private CameraFlight _camera;
    [SerializeField] private Timer _timer;

    [SerializeField] private Score _score;

    [SerializeField] private Background _background;
    [SerializeField] private ParticleSystem _particle;

    [SerializeField] private MusicController _musicController;

    private AudioSource _audio;

    public bool IsGame { get; private set; }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _camera.OnStateMenuPl();
        _background.OnMenu();
        StopGame();
        _buttonStart.OnStartOn();
        AudioPlay();
    }

    private void OnEnable()
    {
        _musicController.SwitchOn += AudioPlay;
        _musicController.SwitchOff += AudioStop;
    }

    private void OnDisable()
    {
        _musicController.SwitchOn -= AudioPlay;
        _musicController.SwitchOff -= AudioStop;
    }

    public void StartGame() => IsGame = true;
    public void StopGame() => IsGame = false;

    public void OnButtonStartClick()
    {
        if (_buttonStart.IsIdleButton)
        {
            StartGame();
            _buttonStart.OnStartOff();
            _background.GameChange();
            _player.PlayerReady();
            _camera.OnGamePl();
            _particle.Stop();
            AudioStop();
        }
    }

    public void OnButtonMenuClick()
    {
        if (_buttonMenu.IsIdleButton)
        {
            YandexGame.FullscreenShow();

            StopGame();
            _buttonMenu.OnStartOff();
            _background.MenuNavigation();
            _camera.OnMenuPl();
            _player.StopDance();
            _player.PlayerWaiting();
            _buttonStart.OnStartOn();
            _timer.ResetTime();
            _score.ShowCurrentScore();
            _particle.Play();
            AudioPlay();
        }
    }

    private void AudioPlay()
    {
        if (_musicController.IsOnMusic)
            _audio.Play();
    }

    private void AudioStop() =>
        _audio.Stop();
}
