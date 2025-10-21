using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UserInput))]
[RequireComponent (typeof(ScopeCounter))]
[RequireComponent(typeof(SpawnerBullet))]
public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _shootCooldown = 0.5f;

    private SpawnerBullet _bulletSpawner;
    private UserInput _userInput;
    private ScopeCounter _scopeCounter;
    private bool _canShoot = true;

    private void Awake()
    {
        _bulletSpawner = GetComponent<SpawnerBullet>();
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
        _bulletSpawner.HandleShoot(_firePoint.position, direction, _scopeCounter);
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
