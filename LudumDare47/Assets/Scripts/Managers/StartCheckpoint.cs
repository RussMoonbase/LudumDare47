using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCheckpoint : MonoBehaviour
{
   public bool lapStarted = false;
   public int thisCheckPointNumber;

   private void Start()
   {

   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         if (PastSelvesManager.instance.isRecording && lapStarted)
         {
            if (thisCheckPointNumber == RaceManager.instance.nextCheckpointNumber)
            {
               PastSelvesManager.instance.isRecording = false;
               PastSelvesManager.instance.canSpawn = true;
               lapStarted = false;
            }
            
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player")
      {
         if (!lapStarted)
         {
            lapStarted = true;
         }

         //Debug.Log("Player hit checkpoint");
         if (!PastSelvesManager.instance.isRecording)
         {
            PastSelvesManager.instance.isRecording = true;
         }
      }

   }
}
