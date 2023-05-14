using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawnLoc : MonoBehaviour
{
   public static PlayerSpawnLoc instance;
   public Transform[] spawnPoints;

   private void Start() {
       instance = this;
   }
}
