using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using Application = UnityEngine.Application;

public class UIType : MonoBehaviour
{
    public Transform playerTransform;
    public Transform objectTransform;

    [SerializeField]
    private bool isFollowing;

    public float cameraDistance = 3.0f;
    public float followDelay = 10f;
    public float followTime = 0.1f;

    [SerializeField]
    private bool isFocusing;

    public float focusDelay = 10f;

    [SerializeField]
    private bool isFixing;

    private void Update()
    {
        if (isFollowing && !isFocusing && !isFixing)
        {
            FollowUI();
        }
        else
        {
            if (isFocusing && isFixing)
            {
                FocusUI();
                FixUI();
            }
            else if (isFocusing && !isFixing)
            {
                FocusUI();
            }
            else if (!isFocusing && isFixing)
            {
                FixUI();
            }
        }
    }

    private void FollowUI()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.TransformPoint(new Vector3(0, 0, cameraDistance));
            Vector3 targetDirection = playerTransform.position - this.transform.position;
            Vector3 velocity = Vector3.zero;

            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, followTime);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(-targetDirection), followDelay * Time.deltaTime);
        }
    }

    private void FocusUI()
    {
        if (playerTransform != null)
        {
            Vector3 targetDirection = playerTransform.position - this.transform.position;

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(-targetDirection), focusDelay * Time.deltaTime);
        }
    }

    private void FixUI()
    {
        if (objectTransform != null)
        {
            this.transform.position = objectTransform.position;
        }
    }
}
