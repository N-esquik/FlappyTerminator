using UnityEngine;
[RequireComponent (typeof(StartScreen),typeof(EndGameScreen))]
public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private ScopeCounter _scope;

    private StartScreen _startScreen;
    private EndGameScreen _endScreen;

    private void Awake()
    {
        _startScreen = GetComponent<StartScreen>();
        _endScreen = GetComponent<EndGameScreen>();
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
        _enemyGenerator.ResetEnemy();

        StartGame();
    }

    private void StartGame()
    {
        _startScreen.Close();
        _bird.Reset();
        _bulletPool.Reset();
        _enemyGenerator.ResetEnemy();
        _scope.Reset();
        Time.timeScale = 1;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }
}
