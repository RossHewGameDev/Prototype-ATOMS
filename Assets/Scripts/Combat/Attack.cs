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
        if (agentParent != null)
        {
            agent = agentParent.GetComponent<Agent>();
        }
        else
        {
            Debug.LogWarning("No Agent for GetAgentProperties");
        }

    }



    /// <summary>
    /// Damages the agent that the weapon is locked onto. 
    /// Move this to agent's responsibility? (reduce agent health and add agent heatlh on agent?)
    /// </summary>
    /// <param name="damage"></param>
    public void DamageAgent(int damage)
    {
        if (agent != null)
        {
            agent.CurrentHealth -= damage;
        }

    }
}
