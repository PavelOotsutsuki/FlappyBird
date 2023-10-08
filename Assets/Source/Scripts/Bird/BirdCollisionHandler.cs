using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour, IInitiazable<Bird>
{
    private Bird _bird;

    public void Init(Bird parentBird)
    {
        _bird = parentBird;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ScoreArea scoreArea))
        {
            _bird.IncreaseScore();
        }
        else
        {
            _bird.Die();
        }
    }
}
