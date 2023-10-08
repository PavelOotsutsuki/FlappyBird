using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMovement : MonoBehaviour, IInitiazable
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 300f;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private bool _isStart;

    public void Init()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartFly();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isStart)
            {
                InFly();
            }

            _rigidbody2D.velocity = new Vector2(_speed, 0f);
            transform.rotation = _maxRotation;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
            
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
        enabled = true;
    }

    public void StartFly()
    {
        _isStart = true;
        _maxRotation = Quaternion.identity;
        _minRotation = Quaternion.identity;
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void InFly()
    {
        _isStart = false;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

}
