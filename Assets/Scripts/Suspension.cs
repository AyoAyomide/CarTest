using UnityEngine;

public class Suspension : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _restDistance;

    [SerializeField] Transform _rayPoint;

    private void FixedUpdate()
    {
        CalculateSuspension();
    }

    private void CalculateSuspension()
    {
        RaycastHit hit;


        if (Physics.Raycast(_rayPoint.position, -_rayPoint.up, out hit, _restDistance))
        {

            Debug.DrawLine(_rayPoint.position, hit.point, Color.green);
        }
        else
        {
            Vector3 endpoint = _rayPoint.position - _rayPoint.up * _restDistance;
            Debug.DrawLine(_rayPoint.position, endpoint, Color.red);
        }
    }
}