using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMelee : Attack
{
    // not where we create weapons. We'll create a scriptable object for that.
    string weaponName = "Test Melee";

    [SerializeField] GameObject weaponHolder; // assign this on awake 

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

    }

    /// <summary>
    /// Activates the weapon and attacks the current target.
    /// </summary>
    public void WeaponFire()
    {
        DamageAgent(Damage);
    }
}
 