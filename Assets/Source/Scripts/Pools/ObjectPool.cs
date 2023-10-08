using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ObjectPool : MonoBehaviour, IInitiazable<Camera>
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _countObjects;
    [SerializeField] private GameObject _template;
    [SerializeField] protected float ExtraLenght;

    protected int CountIterationEnable = 0;
    protected float StartPositionX;
    protected Camera Camera;
    protected Vector3 StartDisablePoint;
    protected float CameraLength;

    private List<GameObject> _pool = new List<GameObject>();

    public virtual void Init(Camera camera)
    {
        Camera = camera;
        StartDisablePoint = Camera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        CameraLength = Camera.ViewportToWorldPoint(new Vector2(1, 0.5f)).x - StartDisablePoint.x;

        for (int i = 0; i < _countObjects; i++)
        {
            GameObject spawned = Instantiate(_template, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen(float extraLength = 0)
    {
        Vector3 disablePoint = Camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (GameObject item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x - extraLength)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (GameObject item in _pool)
        {
            item.SetActive(true);
            item.SetActive(false);
        }

        CountIterationEnable = 0;
    }
}
