using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachinePOVextension : CinemachineExtension
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float clampAngle = 80f;
    private Vector3 startingRotation;
    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation == null)
                {
                    startingRotation = transform.localRotation.eulerAngles;
                    float mouseX = Input.GetAxis("Mouse X");
                    float mouseY = Input.GetAxis("Mouse Y");
                    startingRotation.x += mouseX * verticalSpeed * Time.deltaTime;
                    startingRotation.y += mouseY * horizontalSpeed * Time.deltaTime;
                    startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                    state.RawOrientation = Quaternion.Euler(startingRotation.y , startingRotation.x , 0f);
                }
            }
        }
    }
}
