using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public Transform target;
    public float angularSpeed;

    [SerializeField]
    [HideInInspector]
    private Vector3 initialOffset;

    private Vector3 currentOffset;

    private float movement;

    [ContextMenu("Set Current Offset")]
    private void SetCurrentOffset()
    {
        if (target == null)
        {
            return;
        }

        initialOffset = transform.position - target.position;
    }

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Assign a target for the camera in Unity's inspector");
        }

        currentOffset = initialOffset;
    }

    private void LateUpdate()
    {
        transform.position = target.position + currentOffset;
		float mouseXPosition = Input.mousePosition.x;

        if (mouseXPosition < 20 || Input.GetKey(KeyCode.Q))
        {
            movement = -1f * angularSpeed * Time.deltaTime;
        }
        else if (Screen.width - 20 < mouseXPosition || Input.GetKey(KeyCode.E))
        {
            movement = 1f * angularSpeed * Time.deltaTime;
        }
        else
        {
            movement = 0;
        }

        if (!Mathf.Approximately(movement, 0f))
        {
            transform.RotateAround(target.position, Vector3.up, movement);
            currentOffset = transform.position - target.position;
        }
    }
}

