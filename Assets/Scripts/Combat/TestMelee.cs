using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMelee : Attack
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamageAgent(Damage);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        GetAgentProperties(other.gameObject);
    }


}
