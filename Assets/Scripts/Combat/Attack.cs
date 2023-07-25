using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{

    public enum WeaponType
    {
        Melee,
        Ranged // to be implemented later, also clasifications may change.
    }

    public WeaponType WeaponRange;
    public int Damage;

    [SerializeField] Agent agent; // Serialised for debugging view.
 
    /// <summary>
    /// Grabs the agent component of this gameobject.
    /// </summary>
    /// <param name="agentParent"></param>
    public void GetAgentProperties(GameObject agentParent)
    {
        agent = agentParent.GetComponent<Agent>();
    }

    public void DamageAgent(int damage)
    {
        agent.CurrentHealth -= damage;
    }
}
