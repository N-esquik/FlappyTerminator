using UnityEngine;

[RequireComponent(typeof(BulletPool))]
[RequireComponent (typeof(Bullet))]
public class SpawnerBullet : MonoBehaviour
{
    private BulletPool _bulletPool;
    private Bullet _bullet;

    private void Awake()
    {
        _bulletPool = GetComponent<BulletPool>();
        _bullet = GetComponent<Bullet>();
    }

    private void OnEnable()
    {
        _bullet.PoolReturned += ReturnPool;
    }
   
    private void OnDisable()
    {
        _bullet.PoolReturned -= ReturnPool;
    }

    public void HandleShoot(Vector3 position, Vector2 direction, ScopeCounter scopeCounter = null)
    {
        var bullet = _bulletPool.GetObject();
    
        bullet.transform.position = position;
        bullet.gameObject.SetActive(true);
        bullet.Init(direction, scopeCounter);
    }

    public void ReturnPool()
    {
        _bulletPool.ReturnObjectPool(_bullet);
    }
}
