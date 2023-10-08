public class GameActivator 
{
    private ObjectPool[] _pools;
    private Bird _bird;
    private GameOverScreen _gameOverScreen;
    private StartScreen _startScreen;
    
    public GameActivator(ObjectPool[] pools, Bird bird, GameOverScreen gameOverScreen, StartScreen startScreen)
    {
        _pools = pools;
        _bird = bird;
        _gameOverScreen = gameOverScreen;
        _startScreen = startScreen;
    }

    public void StartGame()
    {
        _startScreen.Open();
    }

    public void ResetGame()
    {
        foreach (ObjectPool pool in _pools)
        {
            pool.ResetPool();
        }

        _bird.ResetPlayer();
        _bird.DisplayScore();
        _gameOverScreen.Close();
        _startScreen.Close();
    }

    public void ActivateGameOver()
    {
        _gameOverScreen.Open();
    }
}
