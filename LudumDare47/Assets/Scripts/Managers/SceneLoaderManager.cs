using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
   public static SceneLoaderManager instance;
   private int sceneNumber;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void LoadNextScene()
   {
      sceneNumber = SceneManager.GetActiveScene().buildIndex;
      sceneNumber++;
      SceneManager.LoadScene(sceneNumber);
   }

   public void LoadStartScene()
   {
      SceneManager.LoadScene(0);
   }

   public void LoadWinScene()
   {
      SceneManager.LoadScene(3);
   }
}
