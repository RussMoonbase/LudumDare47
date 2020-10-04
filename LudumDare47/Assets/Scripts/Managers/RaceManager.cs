using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
   public static RaceManager instance;
   public Checkpoint[] checkPoints;
   public int totalcheckPoints;
   public int currentLap;
   public int maxLaps;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      totalcheckPoints = checkPoints.Length;

      if (checkPoints.Length != 0)
      {
         for (int i = 0; i < checkPoints.Length; i++)
         {
            checkPoints[i].checkPointNum = i;
         }
      }

      currentLap = 1;
      UIManager.instance.currentLapText.text = currentLap.ToString();
      UIManager.instance.maxLapsText.text = maxLaps.ToString();
      //Debug.Log("Current Lap = " + currentLap);
   }

   // Update is called once per frame
   void Update()
   {
      
   }
}
