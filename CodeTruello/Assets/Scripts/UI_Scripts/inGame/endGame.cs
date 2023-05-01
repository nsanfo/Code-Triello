using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public string prefabName = "playerPrefab";
    private bool hasDuplicates = false;
    private int prefabCount = 0;
    private Dictionary<int, GameObject> instances = new Dictionary<int, GameObject>();

    private void Update()
    {
        // Get all instances of the prefab in the scene
        GameObject[] instancesArray = GameObject.FindGameObjectsWithTag(prefabName);

        // Update the count of instances
        prefabCount = instancesArray.Length;
        Debug.Log("num of player prefabs in scene: " + prefabCount);

        // Check if there are duplicates
        for (int i = 0; i < instancesArray.Length; i++)
        {
            int instanceID = instancesArray[i].GetInstanceID();

            if (instances.ContainsKey(instanceID))
            {
                hasDuplicates = true;
                break;
            }
            else
            {
                instances.Add(instanceID, instancesArray[i]);
            }
        }

        // If the prefab count has decreased from 2 after starting a game, call a function on the prefab
        if (hasDuplicates && prefabCount < 2)
        {
            // Call the function on the prefab
            foreach (var instance in instances.Values) {
                // instance.GetComponent<endVisuals>().EndGameFunction();
            }
            // Reset the bool and dictionary
            hasDuplicates = false;
            instances.Clear();
        }
    }
}