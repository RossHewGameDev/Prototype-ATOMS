using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UICommands : MonoBehaviour
{
    public void UIFollowObject(GameObject _target, GameObject _UI, Camera _camera)
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(_target.transform.position);

        screenPos.z = 0;
        _UI.transform.position = screenPos;
    }


}
