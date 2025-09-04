using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _target;
    [SerializeField] private float _offset = -1;

    private void LateUpdate()
    {
        if (_target == null)
            return;

        Follow();
    }

    private void Follow()
    {
        var position = transform.position;
        position.x = _target.transform.position.x + _offset;
        transform.position = position;
    }
}
