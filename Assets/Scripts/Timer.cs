using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _display;
    [SerializeField] private Player _player;

    [SerializeField] private Controller _entry;

    public event UnityAction<int> StopScore;

    private float _time;

    private void Start()
    {
        ResetTime();
    }

    private void Update()
    {
        if (_entry.IsGame)
        {
            if (_player.Lose == false)
                _time += Time.deltaTime;
            else
                StopScore?.Invoke(GetCurrentScore());

            _display.text = Mathf.Round(_time).ToString();
        }
    }

    public int GetCurrentScore() => (int)_time;

    public void ResetTime() => _time = 0;
}
