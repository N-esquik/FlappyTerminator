using UnityEngine;

public class BulletRemover : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Bullet bullet))
        {
            _bulletPool.ReturnBullet(bullet);
        }
    }
}
