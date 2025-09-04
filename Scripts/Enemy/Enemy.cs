using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BulletPool))]
[RequireComponent (typeof(EnemyPool))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _shootInterval;
    [SerializeField] private Transform _firePoint;

    private Rigidbody2D _rigidbody;
    private EnemyPool _objectPool;
    private BulletPool _bulletPool;

    private float _speed;
    private float _shootTimer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _bulletPool = GetComponent<BulletPool>();
        _objectPool = GetComponent<EnemyPool>();
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
        _objectPool.ReturnObjectPool(this);
    }

    public void Init(float speed, BulletPool bulletPool = null)
    {
        _speed = speed;
        _rigidbody.velocity = new Vector2(_speed, 0);
    }

    private void Shoot()
    {
        _bulletPool.HandleShoot(_bulletPool, _firePoint.position, Vector2.left);
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