using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   public AudioSource musicSource;
   public AudioClip[] musicClips;
   private int randomTrackNum;

   // Start is called before the first frame update
   void Start()
   {
      randomTrackNum = Random.Range(0, musicClips.Length);
      musicSource.clip = musicClips[randomTrackNum];
      musicSource.Play();
   }

   // Update is called once per frame
   void Update()
   {
      if (!musicSource.isPlaying)
      {
         randomTrackNum = Random.Range(0, musicClips.Length);
         musicSource.clip = musicClips[randomTrackNum];
         musicSource.Play();
      }
   }
}
