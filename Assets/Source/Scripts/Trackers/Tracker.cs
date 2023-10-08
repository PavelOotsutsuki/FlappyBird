using UnityEngine;

public abstract class Tracker : MonoBehaviour, IInitiazable<Bird>
{
    protected Bird MainBird;
    protected float BirdPositionX;

    public void Init(Bird mainBird)
    {
        MainBird = mainBird;
        BirdPositionX = MainBird.transform.position.x;
    }
}
