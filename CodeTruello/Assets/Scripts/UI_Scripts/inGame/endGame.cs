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
        for (int i = 1; i < instancesArray.Length; i++)
        {
            int instanceID = instancesArray[i].GetInstanceID();

            if (instances.ContainsKey(instanceID) && prefabCount>1)
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
            GameObject[] instancesArray2 = GameObject.FindGameObjectsWithTag(prefabName);

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
        
            // if (instancesArray2.Length == 0) {
            //     Debug.Log("No instances found with tag " + prefabName);
            // } else {
            //     // Find a specific instance by name
            //     foreach (var instance2 in instancesArray2)
            //     {
            //         if (instance2 != null && instance2.GetComponent<endVisuals>() != null)
            //         {
            //             instance2.GetComponent<endVisuals>().EndGameFunction();
            //             Debug.Log("End Game!");
            //             break;
            //         }
            //         else if (instance2.GetComponent<endVisuals>() == null){
            //             Debug.Log("NULLLLLLLLL");
            //         }
            //     }
            // }
            // // // Call the function on the prefab
            // foreach (var instance in instances.Values) {
            //     instance.GetComponent<endVisuals>().EndGameFunction();
            //     Debug.Log("End Game!");
            //     break;
            // }
            // Reset the bool and dictionary
            hasDuplicates = false;
            instances.Clear();
        }
    }
}