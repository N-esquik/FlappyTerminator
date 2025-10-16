using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletPool))]
[RequireComponent(typeof(UserInput))]
[RequireComponent (typeof(ScopeCounter))]
public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _shootCooldown = 0.5f;

    private BulletPool _bulletPool;
    private UserInput _userInput;
    private ScopeCounter _scopeCounter;
    private bool _canShoot = true;

    private void Awake()
    {
        _bulletPool = GetComponent<BulletPool>();
        _userInput = GetComponent<UserInput>();
        _scopeCounter = GetComponent<ScopeCounter>();
    }

    private void OnEnable()
    {
        _userInput.ShootingPressed += HandleShooting;
    }

    private void OnDisable()
    {
        _userInput.ShootingPressed -= HandleShooting;

    }

    private void Shoot()
    {
        Vector2 direction = (_firePoint.position - transform.position).normalized;
        _bulletPool.HandleShoot(_bulletPool, _firePoint.position, direction, _scopeCounter);
    }

    private void HandleShooting()
    {
        if (_canShoot)
        {
            Shoot();
            StartCoroutine(ShootCooldown());
        }
    }

    private IEnumerator ShootCooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_shootCooldown);
        _canShoot = true;
    }
}
