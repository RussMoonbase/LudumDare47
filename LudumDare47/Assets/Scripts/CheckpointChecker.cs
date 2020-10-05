using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChecker : MonoBehaviour
{
   public int currentCheckPoint;
   private int nextCheckpointNum;

   // delete later


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
      //if (other.tag == "Checkpoint")
      //{
      //   currentCheckPoint = other.GetComponent<Checkpoint>().checkPointNum;
      //   //Debug.Log("Current checkpoint = " + currentCheckPoint);
      //   Debug.Log("nextCheckpointNum checkpoint num = " + nextCheckpointNum);

      //   if (currentCheckPoint == nextCheckpointNum)
      //   {
      //      nextCheckpointNum++;

      //      if (nextCheckpointNum == RaceManager.instance.totalcheckPoints)
      //      {
      //         nextCheckpointNum = 0;
      //         RaceManager.instance.currentLap++;

      //         if (RaceManager.instance.currentLap <= RaceManager.instance.maxLaps)
      //         {
      //            UIManager.instance.currentLapText.text = RaceManager.instance.currentLap.ToString();
      //         }

      //      }
      //   }
      //}
      if (other.tag == "Checkpoint")
      {
         currentCheckPoint = other.GetComponent<Checkpoint>().checkPointNum;
         Debug.Log("Current checkpoint = " + currentCheckPoint);
         Debug.Log("nextCheckpointNum checkpoint num = " + RaceManager.instance.nextCheckpointNumber);

         if (currentCheckPoint == RaceManager.instance.nextCheckpointNumber)
         {
            RaceManager.instance.nextCheckpointNumber++;

            if (RaceManager.instance.nextCheckpointNumber == RaceManager.instance.totalcheckPoints)
            {
               RaceManager.instance.nextCheckpointNumber = 0;
               RaceManager.instance.currentLap++;

               if (RaceManager.instance.currentLap <= RaceManager.instance.maxLaps)
               {
                  UIManager.instance.currentLapText.text = RaceManager.instance.currentLap.ToString();
               }

            }
         }
      }

   }

}
