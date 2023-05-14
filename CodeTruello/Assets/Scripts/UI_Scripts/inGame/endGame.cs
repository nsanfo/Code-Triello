using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public string[] prefabNames = { "Player1", "Player2" };
    private bool hasDuplicates = false;
    private int prefabCount = 0;
    private Dictionary<int, GameObject> instances = new Dictionary<int, GameObject>();

    private void Update()
    {
        // Get all instances of the prefabs in the scene
        GameObject[] instancesArray = FindGameObjectsWithTags(prefabNames);

        // Filter out instances that don't have names including "playerPrefab"
        instancesArray = FilterInstancesByName(instancesArray, "playerPrefab");

        // Update the count of instances
        prefabCount = instancesArray.Length;
        Debug.Log("num of player prefabs in scene: " + prefabCount);

        // Check if there are duplicates
        for (int i = 1; i < instancesArray.Length; i++)
        {
            int instanceID = instancesArray[i].GetInstanceID();

            if (instances.ContainsKey(instanceID) && prefabCount > 1)
            {
                hasDuplicates = true;
                break;
            }
            else
            {
                instances.Add(instanceID, instancesArray[i]);
            }
        }

        Debug.Log("Duplicates?: " + hasDuplicates);

        if (hasDuplicates && prefabCount < 2)
        {
            GameObject[] instancesArray2 = FindGameObjectsWithTags(prefabNames);

            // Filter out instances that don't have names including "playerPrefab"
            instancesArray2 = FilterInstancesByName(instancesArray2, "playerPrefab");

            // Find a specific instance by name
            foreach (var instance2 in instancesArray2)
            {
                if (instance2 != null)
                {
                    endVisuals endVisuals = instance2.transform.root.GetComponentInChildren<endVisuals>();
                    if (endVisuals != null)
                    {
                        Debug.Log("End Game!");
                        endVisuals.EndGameFunction();
                        break;
                    }
                    else
                    {
                        Debug.Log("EndVisuals component not found!");
                    }
                }
            }

            // Reset the bool and dictionary
            hasDuplicates = false;
            instances.Clear();
        }
    }

    private GameObject[] FindGameObjectsWithTags(string[] tags)
    {
        // Create a list to store the found GameObjects
        List<GameObject> foundObjects = new List<GameObject>();

        // Iterate over each tag name
        foreach (string tag in tags)
        {
            // Find GameObjects with the current tag and add them to the list
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
            foundObjects.AddRange(objectsWithTag);
        }

        // Convert the list to an array and return it
        return foundObjects.ToArray();
    }

    private GameObject[] FilterInstancesByName(GameObject[] instancesArray, string nameFilter)
    {
        List<GameObject> filteredInstances = new List<GameObject>();

        foreach (var instance in instancesArray)
        {
            if (instance.name.Contains(nameFilter))
            {
                filteredInstances.Add(instance);
            }
        }

        return filteredInstances.ToArray();
    }
}
