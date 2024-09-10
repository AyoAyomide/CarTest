using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform[] rayPoints;
    [SerializeField] LayerMask drivable;

    [Header("Suspension Settings")]
    [SerializeField] float springStiffness;
    [SerializeField, Range(2190,10954)] float dampersStiffness;
    [SerializeField] float restLength;
    [SerializeField] float springTravel;
    [SerializeField] float wheelRadius;

    private void FixedUpdate()
    {
        Suspension();
    }

    private void Suspension()
    {
        foreach (Transform rayPoint in rayPoints)
        {

            RaycastHit hit;
            float maxLength = restLength + springTravel;

            if (Physics.Raycast(rayPoint.position, -rayPoint.up, out hit, maxLength + wheelRadius, drivable))
            {
                float currentSpringLength = hit.distance - wheelRadius;
                float springCompression = (restLength - currentSpringLength) / springTravel;

                float springVelocity = Vector3.Dot(_rb.GetPointVelocity(rayPoint.position), rayPoint.up);
                float dampForce = dampersStiffness * springVelocity;

                float springForce = springStiffness * springCompression;

                float netForce = springForce - dampForce;

                _rb.AddForceAtPosition(netForce * rayPoint.up, rayPoint.position);

                Debug.DrawLine(rayPoint.position, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(rayPoint.position, rayPoint.position + (wheelRadius + maxLength) * -rayPoint.up, Color.red);
            }
        }

    }
}
