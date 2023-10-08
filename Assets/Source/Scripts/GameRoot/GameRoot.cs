using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private Camera _camera;
    private Score _score;
    private Roof[] _roofs;
    private StartScreen _startScreen;
    private GameOverScreen _gameOverScreen;
    private Bird _bird;
    private Tracker[] _trackers;
    private ObjectPool[] _pools;

    private GameActivator _gameActivator;

    private void Start()
    {
        GetAllComponents();
        InitAll();

        _gameActivator.StartGame();
    }

    private void InitAll()
    {
        Init(_score);
        Init(_roofs, _camera);
        Init(_pools, _camera);
        Init(_startScreen, _gameActivator);
        Init(_gameOverScreen, _gameActivator);
        Init(_bird, _gameActivator, _score);
        Init(_trackers, _bird);
    }

    private void GetAllComponents()
    {
        _camera = Camera.main;
        _score = GetComponentInChildren<Score>();
        _roofs = GetComponentsInChildren<Roof>();
        _startScreen = GetComponentInChildren<StartScreen>();
        _gameOverScreen = GetComponentInChildren<GameOverScreen>();
        _bird = GetComponentInChildren<Bird>();
        _trackers = GetComponentsInChildren<Tracker>();
        _pools = GetComponentsInChildren<ObjectPool>();

        _gameActivator = new GameActivator(_pools, _bird, _gameOverScreen, _startScreen);
    }

    private void Init(IInitiazable initializer)
    {
        initializer.Init();
    }

    private void Init(IInitiazable[] initializers)
    {
        foreach (IInitiazable initializer in initializers)
        {
            initializer.Init();
        }
    }

    private void Init<T>(IInitiazable<T> initializer, T parametr)
    {
        initializer.Init(parametr);
    }

    private void Init<T>(IInitiazable<T>[] initializers, T parametr)
    {
        foreach (IInitiazable<T> initializer in initializers)
        {
            initializer.Init(parametr);
        }
    }

    private void Init<T,U>(IInitiazable<T,U> initializer, T parametr1, U parametr2)
    {
        initializer.Init(parametr1,parametr2);
    }
}
