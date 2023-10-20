using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Buttons _buttonStart;
    [SerializeField] private Buttons _buttonMenu;
    [SerializeField] private CameraFlight _camera;
    [SerializeField] private Timer _timer;

    [SerializeField] private Background _background;

    public bool IsGame { get; private set; }

    private void Start()
    {
        _camera.OnStateMenuPl();
        _background.OnMenu();
        StopGame();
        _buttonStart.OnStartOn();
    }

    public void StartGame() => IsGame = true;
    public void StopGame() => IsGame = false;

    public void OnButtonStartClick()
    {
        StartGame();
        _buttonStart.OnStartOff();
        _background.GameChange();
        _player.PlayerReady();
        _camera.OnGamePl();
    }

    public void OnButtonMenuClick()
    {
        StopGame();
        _buttonMenu.OnStartOff();
        _background.MenuNavigation();
        _camera.OnMenuPl();
        _player.StopDance();
        _player.PlayerWaiting();
        _buttonStart.OnStartOn();
        _timer.ResetTime();
    }
}
