using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChecker : MonoBehaviour
{
   public int currentCheckPoint;
   private int nextCheckpointNum;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Checkpoint")
      {
         currentCheckPoint = other.GetComponent<Checkpoint>().checkPointNum;
         Debug.Log("Current checkpoint = " + currentCheckPoint);

         if (currentCheckPoint == nextCheckpointNum)
         {
            nextCheckpointNum++;

            if (nextCheckpointNum == RaceManager.instance.totalcheckPoints)
            {
               nextCheckpointNum = 0;
               RaceManager.instance.currentLap++;
            }
         }


         //Debug.Log("Current checkpoint = " + currentCheckPoint);
      }
   }
}
