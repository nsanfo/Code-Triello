using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameObject;
    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(photonView.IsMine) {
            // the player is local
            LocalXRRigGameObject.SetActive(true);
            SetLayerRecursively(AvatarHeadGameObject, 6);
            SetLayerRecursively(AvatarBodyGameObject, 7);

            TeleportationArea[] teleportAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if(teleportAreas.Length > 0) {
                foreach(var item in teleportAreas) {
                    item.teleportationProvider = LocalXRRigGameObject.GetComponent<TeleportationProvider>();
                }
            }

        } else {
            // the player is remote
            LocalXRRigGameObject.SetActive(false);

            SetLayerRecursively(AvatarHeadGameObject, 0);
            SetLayerRecursively(AvatarBodyGameObject, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
