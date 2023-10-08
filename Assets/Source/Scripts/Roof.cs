using UnityEngine;

public class Roof : MonoBehaviour, IInitiazable<Camera>
{
    public void Init(Camera camera)
    {
        float positionY = camera.ViewportToWorldPoint(new Vector2(0, 1f)).y;
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
    }
}
