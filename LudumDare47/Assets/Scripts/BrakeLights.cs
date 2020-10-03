using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeLights : MonoBehaviour
{
   public bool isBraking;

   private Material[] mats;
   [SerializeField] private Material brakeOnMat;
   private Material brakeOffMat;
   [SerializeField] private MeshRenderer mRenderer;

   // Start is called before the first frame update
   void Start()
   {
      if (mRenderer != null)
      {
         mats = mRenderer.materials;
         brakeOffMat = mats[5];
      }
   }

   // Update is called once per frame
   void Update()
   {
      if (isBraking)
      {
         mats[5] = brakeOnMat;
         mRenderer.materials = mats;
      }

      if (!isBraking && mats[5] == brakeOnMat)
      {
         mats[5] = brakeOffMat;
         mRenderer.materials = mats;
      }
   }
}
