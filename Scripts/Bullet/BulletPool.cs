using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _bullet;

    private Queue<Bullet> _pool;

    private void Awake()
    {
        _pool = new Queue<Bullet>();    
    }

    public Bullet GetBullet()
    {
        if(_pool.Count == 0)
        {
            var bullet = Instantiate(_bullet);
            bullet.transform.parent = _container;
            
            return bullet;
        }

        return _pool.Dequeue();
    }

    public void ReturnBullet(Bullet bullet)
    {
        _pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }

    public void Reset() 
    { 
        foreach (Transform child in _container)
        {
            if (child.gameObject.activeSelf)
            {
                ReturnBullet(child.GetComponent<Bullet>());
            }

            _pool.Clear();
        }
    }
}

