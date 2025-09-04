using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private BirdCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
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
        _birdMover.ResetBird();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Enemy || interactable is Ground || interactable is Bullet)
        {
            GameOver?.Invoke();
        }
    }
}
