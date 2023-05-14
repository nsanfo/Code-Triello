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
        //gotoMenuButton.GetComponent<Button>().onClick.AddListener(networkManager.Instance.LeaveRoomAndLoadHomeScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
