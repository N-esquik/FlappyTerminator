using UnityEngine;

public class Game : MonoBehaviour
{
     private Bird _bird;
     private StartScreen _startScreen;
     private EndGameScreen _endScreen;
     private EnemyPool _enemyPool; 
     private BulletPool _bulletPool;
     private ScopeCounter _scope;

    private void Awake()
    {
        _bird = GetComponentInChildren<Bird>();
        _startScreen = GetComponentInChildren<StartScreen>();
        _endScreen = GetComponentInChildren<EndGameScreen>();
        _enemyPool = GetComponentInChildren<EnemyPool>();
        _bulletPool = GetComponentInChildren<BulletPool>();
        _scope = GetComponentInChildren<ScopeCounter>();
    }

    private void Start()
    {
        _startScreen.Open();
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClicked;
        _bird.Died += EndGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _bird.Died -= EndGame;
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
        _enemyPool.Reset();
        
        StartGame();
    }

    private void StartGame()
    {
        _startScreen.Close();
        _bird.Reset();
        _enemyPool.Reset();
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
