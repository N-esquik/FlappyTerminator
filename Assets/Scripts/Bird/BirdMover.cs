using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(UserInput))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private UserInput _userInput;
    private Vector3 _startPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    public Vector3 StartPosition => _startPosition;

    private void Awake()    
    {
        _userInput = GetComponent<UserInput>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0,0, _minRotationZ);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _userInput.JumpPressed += HandleJump;
    }

    private void OnDisable()
    {
        _userInput.JumpPressed -= HandleJump;
    }

    //public void ResetBird()
    //{
    //    transform.position = _startPosition;
    //    transform.rotation = Quaternion.identity;
    //    _rigidbody.velocity = Vector2.zero;
    //}

    private void HandleJump()
    {
        _rigidbody.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }
}
