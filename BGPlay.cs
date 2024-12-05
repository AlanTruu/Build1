using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BGPlay : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    Queue<string> musicQueue = new Queue<string>();
   
    // Start is called before the first frame update
    
    
    void Start()
    {
        musicQueue.Enqueue("osrsHarmony");
        musicQueue.Enqueue("kerning2");
    }

    public void playBGM() {
        string currentSongName = musicQueue.Dequeue();
        AudioClip currentSongClip = Resources.Load<AudioClip>("SoundFX/" + currentSongName);
        musicSource.clip = currentSongClip;
        musicQueue.Enqueue(currentSongName);
        musicSource.Play();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (musicQueue.Count > 0 && !musicSource.isPlaying) {
            playBGM();
        }
    }
}
