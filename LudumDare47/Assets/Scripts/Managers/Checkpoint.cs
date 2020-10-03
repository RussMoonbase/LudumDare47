using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         Debug.Log("Player hit checkpoint");
         if (!PastSelvesManager.instance.isRecording)
         {
            PastSelvesManager.instance.isRecording = true;
         }

         //if (PastSelvesManager.instance.isRecording)
         //{
         //   PastSelvesManager.instance.isRecording = false;
         //   PastSelvesManager.instance.canSpawn = true;
         //}
      }
   }
}
