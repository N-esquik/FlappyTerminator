using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObjectPool<TObject> : MonoBehaviour where TObject : Component
{
    [SerializeField] private TObject _prefab;
    [SerializeField] private Transform _container;

    private Queue<TObject> _pool = new Queue<TObject>();

    private void Awake()
    {
        _pool = new Queue<TObject>();
    }

    public void Reset()
    {
        foreach (Transform child in _container)
        {
            if (child.gameObject.activeSelf)
            {
                ReturnObjectPool(child.GetComponent<TObject>());
            }

            _pool.Clear();
        }
    }

    public TObject GetObject()
    {
        if (_pool.Count == 0)
        {
            var obj = Instantiate(_prefab);
            obj.transform.parent = _container;
        
            return obj;
        }
        
        return _pool.Dequeue();
    }

    public void ReturnObjectPool(TObject tObject)
    {
        _pool.Enqueue(tObject);
        tObject.gameObject.SetActive(false);
    }

    public void HandleShoot(BulletPool bulletPool, Vector3 position, Vector2 direction, ScopeCounter scopeCounter = null)
    {
        var bullet = bulletPool.GetObject();

        bullet.transform.position = position;
        bullet.gameObject.SetActive(true);
        bullet.Init(direction, scopeCounter);
    }
}

