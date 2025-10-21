using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent (typeof(Rigidbody2D))]  
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private BirdCollisionHandler _handler;
    private Rigidbody2D _rigidbody;

    public event Action Died;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        transform.SetPositionAndRotation(_birdMover.StartPosition, Quaternion.identity);
        _rigidbody.velocity = Vector2.zero;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Enemy || interactable is Ground || interactable is Bullet)
        {
            Died?.Invoke();
        }
    }
}
