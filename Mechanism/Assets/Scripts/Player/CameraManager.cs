/*
 * Project Mechanism
 * Last Updated: 10/31/2022
 * 
 * Description: Implementation for managing the camera following the player, as well as collision logic.
 * 
 * Christ is King.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform targetTransform; //obj that the camera follows
    public Transform cameraPivot;     //obj the camera uses to pivot
    public Transform cameraTransform; //Transform of the camera object
    public LayerMask collisionLayers; //The layers we want the camera to collide with
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;

    public float cameraCollisionOffSet = 0.2f; //How much the camera will jump from objs it collides with
    public float minimumCollisionOffSet = 0.2f;
    public float cameraCollisionRadius = 0.2f;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 15;
    public float cameraPivotSpeed = 15;
    public float cameraLookSmoothTime = 1;

    public float lookAngle; //Camera look up&down
    public float pivotAngle; //Camera look left&right
    public float minimumPivotAngle = -90;
    public float maximumPivotAngle = 90;

    //public float normalSensitivity = 10;
    //public float aimSensitivity = 10;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        //lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        //pivotAngle = pivotAngle + (inputManager.cameraInputY * cameraPivotSpeed);
        lookAngle = Mathf.Lerp(lookAngle, lookAngle + (inputManager.cameraInputX * cameraLookSpeed), cameraLookSmoothTime * Time.deltaTime);
        pivotAngle = Mathf.Lerp(pivotAngle, pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed), cameraLookSmoothTime * Time.deltaTime);

        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast
            (cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, 
                Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffSet);
        }

        if (Mathf.Abs(targetPosition) < minimumCollisionOffSet)
        {
            targetPosition = targetPosition - minimumCollisionOffSet;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
