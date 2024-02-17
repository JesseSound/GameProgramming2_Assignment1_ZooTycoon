using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFInder : MonoBehaviour
{



    public void FindNearestObject(Vector3 currentPosition)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("animals");
        Debug.Log("CALLED");

        if (objectsWithTag.Length == 0)
        {
            Debug.LogWarning("No objects found with the specified tag.");
            return;
        }

        Transform nearestObject = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject obj in objectsWithTag)
        {
            Vector3 directionToTarget = obj.transform.position - currentPosition;
            float distance = directionToTarget.sqrMagnitude;

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestObject = obj.transform;
            }
        }

        if (nearestObject != null)
        {
            Debug.Log("Nearest object found: " + nearestObject.name);
            gameObject.transform.position = nearestObject.position;
            Destroy(nearestObject.gameObject);


            // You can now use 'nearestObject' as the reference to the nearest object.
        }
        else
        {
            Debug.LogWarning("Failed to find the nearest object.");
        }
    }
}





