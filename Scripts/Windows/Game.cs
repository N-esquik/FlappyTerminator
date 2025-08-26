using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endScreen;
    [SerializeField] private ObjectPool _objectPool; 
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private ScopeCounter _scope;

    private void Start()
    {
        _startScreen.Open();
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClicked;
        _bird.GameOver += EndGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _bird.GameOver -= EndGame;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _endScreen.Close();
        _bird.Reset();
        _objectPool.Reset();
        
        StartGame();
    }

    private void StartGame()
    {
        _startScreen.Close();
        _bird.Reset();
        _objectPool.Reset();
        _bulletPool.Reset();
        _scope.Reset();
        Time.timeScale = 1;
    }

    private void EndGame() 
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }
}
