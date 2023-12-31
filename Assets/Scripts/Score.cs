using UnityEngine;
using TMPro;
using YG;

public class Score : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    [SerializeField] private TMP_Text _textScore;

    private const string _saveKey = "valueSave";

    private int _maxScore;

    private void Start()
    {
        ShowCurrentScore();
    }

    private void OnEnable()
    {
        _timer.StopScore += OnMemorizeRecord;
    }

    private void OnDisable()
    {
        _timer.StopScore += OnMemorizeRecord;
    }

    public void ShowCurrentScore()
    {
        Load();
        _textScore.text = _maxScore.ToString();
    }

    private void OnMemorizeRecord(int maxScore)
    {
        if (maxScore > _maxScore)
        {
            _maxScore = maxScore;
            Save();
            YandexGame.NewLeaderboardScores("BestCapybars", _maxScore);
        }
    }

    private void Save()
    {
        SaveManager.Save(_saveKey, GetSaveScore());
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveData.ScoreController>(_saveKey);

        _maxScore = data.MaxValue;
    }

    private SaveData.ScoreController GetSaveScore()
    {
        var data = new SaveData.ScoreController()
        {
            MaxValue = _maxScore
        };

        return data;
    }
}
