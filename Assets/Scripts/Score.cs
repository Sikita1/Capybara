using UnityEngine;
using TMPro;
using YG;

public class Score : MonoBehaviour
{
    private const string ValueSave = "valueSave";
    private const string BestCapybars = "BestCapybars";

    [SerializeField] private Timer _timer;

    [SerializeField] private TMP_Text _textScore;

    private const string _saveKey = ValueSave;

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
            YG2.SetLeaderboard(BestCapybars, _maxScore);
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
