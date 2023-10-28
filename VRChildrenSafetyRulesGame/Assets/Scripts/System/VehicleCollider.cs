using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollider : MonoBehaviour
{
    public float vSpeed;
    private Vector3 vPosition;
    public bool isStopping = false;
    public bool isLighting = false;

    private void Start()
    {
        vPosition = this.transform.position;
    }

    private void Update()
    {
        MoveVehicle();
    }

    private void MoveVehicle()
    {
        if (gameObject.activeSelf && !isStopping)
        {
            transform.localPosition += transform.forward * Time.deltaTime * vSpeed;
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag.Equals("End"))
        {
            gameObject.SetActive(false);
            isStopping = false;
            isLighting = false;
            transform.position = vPosition;
        }
        if (hit.transform.tag.Equals("Light"))
        {
            isLighting = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.transform.tag.Equals("Light"))
        {
            isLighting = false;
        }
    }
}
