using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIFollowCamera : MonoBehaviour
{

    public RectTransform UIToRotate;
    public Camera CameraTarget;

    private void Update()
    {
        UIToRotate.LookAt(CameraTarget.transform);
    }

}
