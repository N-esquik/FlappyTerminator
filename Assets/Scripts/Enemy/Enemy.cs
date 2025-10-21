using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent (typeof(EnemyGenerator))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _firePoint;

    private EnemyShooter _enemyShooter;
    private EnemyGenerator _enemyGenerator; 
    
    private void Awake()
    {
        _enemyShooter = GetComponent<EnemyShooter>();
        _enemyGenerator = GetComponent<EnemyGenerator>();
    }

    private void Update()
    {
        _enemyShooter.ShootTimer(_firePoint);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    public void Hit()
    {
        _enemyGenerator.ResetPool(this);
    }
}