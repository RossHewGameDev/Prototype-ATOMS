using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controls movement of Agents
/// </summary>
public class Movement : MonoBehaviour
{
    [Tooltip("enables/disables Agent movement")]
    public bool CanMove;

    [Tooltip("The speed of the Agent")]
    public float Speed;

    [Tooltip("Stopping distance from movementTarget")]
    public float StoppingDistance;

    public Transform movementTarget;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            MoveTowardsTarget();
        }
    }

    /// <summary>
    /// moves rigidbody towards target until within stopping distance.
    /// </summary>
    public void MoveTowardsTarget()
    {
        if (Vector3.Distance(_rb.position, movementTarget.position ) > StoppingDistance)
        {
            _rb.AddForce(FindDirectionVector() * Speed);
        }           
    }


    /// <summary>
    /// returns direction of target.
    /// </summary>
    /// <returns></returns>
    private Vector3 FindDirectionVector()
    {
        Vector3 dir = movementTarget.position - _rb.position;

        return dir.normalized;
    }



}
