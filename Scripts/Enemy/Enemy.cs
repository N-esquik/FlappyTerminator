using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InitBullet))]
[RequireComponent(typeof(BulletPool))]
[RequireComponent (typeof(ObjectPool))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _shootInterval;
    [SerializeField] private Transform _firePoint;

    private Rigidbody2D _rigidbody;
    private ObjectPool _objectPool;
    private BulletPool _bulletPool;
    private InitBullet _initBullet;

    private float _speed;
    private float _shootTimer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _initBullet = GetComponent<InitBullet>();
        _bulletPool = GetComponent<BulletPool>();
        _objectPool = GetComponent<ObjectPool>();
        _shootTimer = _shootInterval;
    }

    private void Update()
    {
        ShootTimer();
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public void Hit()
    {
        _objectPool.PutObject(this);

    }

    public void Init(float speed, BulletPool bulletPool = null)
    {
        _speed = speed;
        _rigidbody.velocity = new Vector2(_speed, 0);
    }

    private void Shoot()
    {
        _initBullet.HandleShoot(_bulletPool, _firePoint.position, Vector2.left);
    }

    private void ShootTimer()
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer < 0)
        {
            Shoot();
            _shootTimer = _shootInterval;
        }
    }
}