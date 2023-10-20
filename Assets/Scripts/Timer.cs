using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _display;
    [SerializeField] private Player _player;

    [SerializeField] private Controller _entry;

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

            _display.text = Mathf.Round(_time).ToString();
        }
    }

    public void ResetTime() => _time = 0;
}
