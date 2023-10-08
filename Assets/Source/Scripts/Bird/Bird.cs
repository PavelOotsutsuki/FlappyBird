using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour, IInitiazable<GameActivator, Score>
{
    private BirdMovement _birdMovement;
    private BirdCollisionHandler _birdCollision;
    private GameActivator _gameActivator;
    private Score _score; 
    private int _scorePoints;

    public void Init(GameActivator gameOverActivator, Score score)
    {
        _gameActivator = gameOverActivator;
        _score = score;

        BirdMovementInit();
        BirdCollisionHandlerInit();
        ResetPlayer();
        DisplayScore();
    }

    public void ResetPlayer()
    {
        _scorePoints = 0;
        _birdMovement.ResetBird();
        _birdMovement.StartFly();
    }

    public void IncreaseScore()
    {
        _scorePoints++;
        DisplayScore();
    }

    public void Die()
    {
        _gameActivator.ActivateGameOver();
        _birdMovement.enabled = false;
    }

    public void DisplayScore()
    {
        _score.ChangeScoreText(_scorePoints);
    }

    private void BirdMovementInit()
    {
        _birdMovement = GetComponent<BirdMovement>();
        _birdMovement.Init();
    }

    private void BirdCollisionHandlerInit()
    {
        _birdCollision = GetComponent<BirdCollisionHandler>();
        _birdCollision.Init(this);
    }
}
