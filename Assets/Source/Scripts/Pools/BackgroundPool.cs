using UnityEngine;

public class BackgroundPool : ObjectPool
{
    public override void Init(Camera camera)
    {
        base.Init(camera);
        StartPositionX = transform.localPosition.x;
    }

    private void Update()
    {
        Vector3 cameraPosition = Camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        if (CountIterationEnable < (cameraPosition.x - StartDisablePoint.x) / ExtraLenght)
        {
            if (TryGetObject(out GameObject ground))
            {
                ground.SetActive(true);
                ground.transform.localPosition = new Vector3(StartPositionX + ExtraLenght * CountIterationEnable, transform.position.y, transform.position.z);
                CountIterationEnable++;
            }

            DisableObjectAbroadScreen(ExtraLenght);
        }
    }
}
