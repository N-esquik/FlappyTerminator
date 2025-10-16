using System;
using TMPro;
using UnityEngine;

public class ScopeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    public event Action<TextMeshProUGUI,int> ValueChanged;

    public void AddScore()
    {
        _score += 1;
        ValueChanged?.Invoke(_scoreText,_score);
    }

    public void Reset()
    {
        _score = 0;
        ValueChanged?.Invoke(_scoreText, _score);
    }
}