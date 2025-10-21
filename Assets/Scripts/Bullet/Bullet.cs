using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour,IInteractable
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody;
    private ScopeCounter _scopeCounter;

    public event Action PoolReturned;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        PoolReturned?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bird bird))
        {
            gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Hit();
            _scopeCounter.AddScore();
            gameObject.SetActive(false);
        }
    }

    public void Init(Vector2 direction,ScopeCounter scopeCounter)
    {
        _scopeCounter = scopeCounter;
        _rigidbody.velocity = direction * _speed;
    }
}
