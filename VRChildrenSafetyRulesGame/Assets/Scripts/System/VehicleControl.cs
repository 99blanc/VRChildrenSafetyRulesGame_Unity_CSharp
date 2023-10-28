using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
    public VehicleCollider[] vehicles;
    public TrafficEffect trafficEffect;
    public GameObject[] endArea;
    public GameObject[] lightArea;
    public float vehicleDelay = 2.5f;
    private bool isSpawning = false;

    private void Update()
    {
        CheckTrafficLight();
        RandomSpawnVehicle();
    }

    private void RandomSpawnVehicle()
    {
        if (!isSpawning)
        {
            isSpawning = true;

            StartCoroutine(SpawnVehicle());
        }
    }

    private IEnumerator SpawnVehicle()
    {
        int rand = Random.Range(0, vehicles.Length);
        vehicles[rand].gameObject.SetActive(true);

        yield return new WaitForSeconds(vehicleDelay);

        isSpawning = false;
    }

    private void CheckTrafficLight()
    {
        if (trafficEffect.redEffect.activeSelf)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].isLighting)
                {
                    vehicles[i].isStopping = false;
                }
            }
        }
        else if (trafficEffect.greenEffect.activeSelf)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].isLighting)
                {
                    vehicles[i].isStopping = true;
                }
            }
        }
    }
}
