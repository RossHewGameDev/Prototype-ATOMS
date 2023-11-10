using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMelee : Attack
{
    // not where we create weapons. We'll create a scriptable object for that.
    string weaponName = "Test Melee"; 

    void Update()
    {
        //Debug atttack button.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WeaponFire();
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {

        TargetSelect(other);

    }


    /// <summary>
    /// Selects a target that is in range. I kinda want to replace this collider method with just a list of all the
    /// enemies and it picks the closest one to be its target.
    /// </summary>
    /// <param name="collider"></param>
    private void TargetSelect(Collider collider)
    {
        if (collider != null && collider.CompareTag("Agent"))
        {
            GetAgentProperties(collider.gameObject);
            Debug.LogWarning("Target for " + weaponName + ": " + collider.name);
        }
    }


    /// <summary>
    /// Activates the weapon and attacks the current target.
    /// </summary>
    public void WeaponFire()
    {
        DamageAgent(Damage);
    }
}
 