using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletPool))]
[RequireComponent(typeof(InitBullet))]
[RequireComponent(typeof(UserInput))]
public class BirdShooter : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _shootCooldown = 0.5f;

    private BulletPool _bulletPool;
    private UserInput _userInput;
    private InitBullet _initBullet;
    private bool _canShoot = true;

    private void Awake()
    {
        _bulletPool = GetComponent<BulletPool>();
        _initBullet = GetComponent<InitBullet>();
        _userInput = GetComponent<UserInput>();
    }

    private void Update()
    {
        HandleShooting();
    }

    private void Shoot()
    {
        Vector2 direction = (_firePoint.position - transform.position).normalized;
        _initBullet.HandleShoot(_bulletPool, _firePoint.position, direction);
    }

    private void HandleShooting()
    {
        if (_userInput.SetKeyCode(UserInput.KeyR) && _canShoot)
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
