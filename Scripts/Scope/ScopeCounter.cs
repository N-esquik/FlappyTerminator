using TMPro;
using UnityEngine;

public class ScopeCounter : MonoBehaviour
{
    public static ScopeCounter Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddScore(int points)
    {
        _score += points;
        UpdateScoreText();
    }

    public void Reset()
    {
        _score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"Очки: {_score}";
        }
    }
}