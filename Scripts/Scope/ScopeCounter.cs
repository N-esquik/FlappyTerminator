using TMPro;
using UnityEngine;

public class ScopeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    public void AddScore()
    {
        _score += 1;
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