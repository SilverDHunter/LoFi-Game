using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpeakerController : MonoBehaviour
{
    void Start()
    {
        leftSpeaker.loop = false;
        rightSpeaker.loop = false;
    }

    #region Speakers

    [Header ("Speaker Controls")]

    /// <summary>
    /// A reference to the left speaker in the speaker set in game.
    /// </summary>
    public AudioSource leftSpeaker;

    /// <summary>
    /// A reference to the right speaker in the speaker set in game.
    /// </summary>
    public AudioSource rightSpeaker;

    /// <summary>
    /// The current audio clip playing in game, which both speakers have to play coordinated.
    /// </summary>
    public AudioClip currentSong;


    /// <summary>
    /// Function that makes sure that both speakers are playing the same song at the same time.
    /// </summary>
    public void CombiningSpeakers ()
    {
        leftSpeaker.clip = currentSong;
        rightSpeaker.clip = currentSong;
    }


    /// <summary>
    /// Plays the music. Used for UI Buttons.
    /// </summary>
    public void PlayStopMusic()
    {
        if (!leftSpeaker.isPlaying)
        {
            currentSong = GetNextClip();
            leftSpeaker.Play();
            rightSpeaker.Play();
            print("music");
        }
        else
        if (leftSpeaker.isPlaying)
        {
            currentSong = GetNextClip();
            leftSpeaker.Pause ();
            rightSpeaker.Pause ();
            print("no music");
        }
    }

    #endregion Speakers

    #region Playlist

    [Header ("Playlist Controls")]
    [Space (10)]

    /// <summary>
    /// Holds the playlist of music clips.
    /// </summary>
    public AudioClip [] clips;

    /// <summary>
    /// The current clip being played, using the index.
    /// </summary>
    private int currentClipIndex = 0;


    /// <summary>
    /// function to get the next clip in order, then repeat from the beginning of the list.
    /// </summary>
    /// <returns> The next song in the playlist. </returns>
    private AudioClip GetNextClip ()
    {
        if (currentClipIndex >= clips.Length - 1)
        {
            currentClipIndex = 0;
        }
        else
        {
            currentClipIndex += 1;
        }
        return clips [currentClipIndex];
    }

    #endregion Playlist

    void Update()
    {
        CombiningSpeakers ();
    }
}