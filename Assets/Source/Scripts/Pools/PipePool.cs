using UnityEngine;

public class PipePool : ObjectPool
{
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    public override void Init(Camera camera)
    {
        base.Init(camera);
        StartPositionX = transform.position.x;
    }

    private void Update()
    {
        Vector3 cameraPosition = Camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        if (CountIterationEnable < (cameraPosition.x - StartDisablePoint.x) / ExtraLenght)
        {
            if (TryGetObject(out GameObject pipe))
            {
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);

                pipe.SetActive(true);
                pipe.transform.position = new Vector3(StartPositionX + ExtraLenght * CountIterationEnable, spawnPositionY, transform.position.z);
                CountIterationEnable++;
            }

            DisableObjectAbroadScreen(ExtraLenght);
        }
    }
}
