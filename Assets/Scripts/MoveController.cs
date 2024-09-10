using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;

    [SerializeField] float _moveSpeed;

    private void FixedUpdate()
    {

        _rb.velocity = transform.forward * _moveSpeed;


    }

}