using UnityEngine;

public class InitBullet : MonoBehaviour
{
    public void HandleShoot(BulletPool bulletPool,Vector3 position, Vector2 direction)
    {
        var bullet = bulletPool.GetBullet();

        bullet.transform.position = position;
        bullet.gameObject.SetActive(true);
        bullet.Init(direction);
    }
}
