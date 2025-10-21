using UnityEngine;

[RequireComponent(typeof(SpawnerBullet))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _shootInterval;

    private SpawnerBullet _spawnerBullet;
    private Vector3 _offset = new Vector3(-5,0,0);
    private float _shootTimer;

    private void Awake()
    {
        _spawnerBullet = GetComponent<SpawnerBullet>();
        _shootTimer = _shootInterval;
    }
    public void ShootTimer(Transform firePoint)
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer < 0)
        {
            Shoot(firePoint);
            _shootTimer = _shootInterval;
        }
    }

    private void Shoot(Transform firePoint)
    {
        _spawnerBullet.HandleShoot(transform.position + _offset,Vector2.left);
    }
}
