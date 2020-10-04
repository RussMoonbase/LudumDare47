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
   }

   // Update is called once per frame
   void Update()
   {

   }
}
