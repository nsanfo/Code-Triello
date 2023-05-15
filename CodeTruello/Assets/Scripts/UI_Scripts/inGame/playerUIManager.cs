using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject gotoMenuButton;
    
    // Start is called before the first frame update
    void Start()
    {
        Button button = gotoMenuButton.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => networkManager.Instance.LeaveRoomAndLoadHomeScreen());
        }
        else
        {
            Debug.LogError("Button reference is null. Make sure the button is assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
