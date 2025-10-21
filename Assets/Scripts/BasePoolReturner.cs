using UnityEngine;

public abstract class BasePoolReturner<TObject> : MonoBehaviour where TObject : Component 
{
    [SerializeField] private BaseObjectPool<TObject> _pool;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out TObject objectReturner))
        {
            _pool.ReturnObjectPool(objectReturner);
        }
    }
}
