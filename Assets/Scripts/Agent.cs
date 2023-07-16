using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{

    public enum AgentType
    {
        Ally,
        Enemy,
        Neutral
    }

    public AgentType agentType;
    public string agentName;




}
