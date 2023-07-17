using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this to object that needs UI tracking it.
public class UITracker : UICommands
{

    [SerializeField] GameObject UI;
    GameObject cameraObject;
    Camera _camera;
     

    void Start()
    {
        cameraObject = GameObject.Find("Main Camera"); // this is bad, change this later.
        _camera = cameraObject.GetComponent<Camera>();

    }

    void Update()
    {
        UIFollowObject(gameObject, UI, _camera);
    }
}
