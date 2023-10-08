using UnityEngine;

public class BackgroundParallax : Tracker
{
    [SerializeField] private float _parallaxFactor;

    private void Update()
    {
        transform.position = new Vector3((MainBird.transform.position.x - BirdPositionX) * _parallaxFactor, transform.position.y, transform.position.z);
    }
}
