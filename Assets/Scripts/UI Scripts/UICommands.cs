using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UICommands : MonoBehaviour
{
    public void UIFollowObject(GameObject _target, GameObject _UI, Camera _camera)
    {

        Vector3 adjustedTransform = _target.transform.position;

        adjustedTransform.y += 2;

        Vector3 screenPos = _camera.WorldToScreenPoint(adjustedTransform);

        screenPos.z = 0;
        //screenPos.y += 50;


        _UI.transform.position = screenPos;
    }


}
