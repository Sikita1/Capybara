using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Buttons _buttonStart;

    public bool IsGame { get; private set; }

    private void Start()
    {
        StopGame();
    }

    public void StartGame() => IsGame = true;
    public void StopGame() => IsGame = false;

    public void OnButtonStartClick()
    {
        StartGame();
        _player.PlayerReady();
        _buttonStart.OnStartOff();
    }
}
