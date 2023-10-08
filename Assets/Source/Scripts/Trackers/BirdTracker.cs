using UnityEngine;

public class BirdTracker : Tracker
{
    private void Update()
    {
        transform.position = new Vector3(MainBird.transform.position.x - BirdPositionX, transform.position.y, transform.position.z);
    }
}
