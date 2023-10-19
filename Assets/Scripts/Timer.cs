using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _display;
    [SerializeField] private Player _player;

    [SerializeField] private EntryPoint _entry;

    private float _time = 0;

    private void Update()
    {
        if (_entry.IsGame)
        {
            if (_player.Lose == false)
                _time += Time.deltaTime;

            _display.text = $"Рекорд: {Mathf.Round(_time).ToString()}";
        }
    }
}
