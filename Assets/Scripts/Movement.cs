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

    Agent _agent;
    Agent.AgentType _agentType;

    GameObject _nextTarget;

    private void Awake()
    {
        _agent = GetComponent<Agent>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {        
        _agentType = _agent.ReturnAgentType(); //Assign agent type
        AcquireTarget();
        CanMove = true;
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
        movementTarget = _nextTarget.transform; //Movement target becomes current target

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

    /// <summary>
    /// Find target depending on this agents type
    /// </summary>
    private void AcquireTarget()
    {
        switch (_agentType) 
        {
            case Agent.AgentType.Ally:
                _nextTarget = FindObjectOfType<Agent>().gameObject;
                break;
            case Agent.AgentType.Enemy:
                _nextTarget = GameObject.Find("Test Ally");
                break;
            default:
                _nextTarget = movementTarget.gameObject;
                break;

        }
    }


}
