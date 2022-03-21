using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject postGameUI, inGameUI;
    [SerializeField] private float noteSpeed;
    [SerializeField] private float startDelay;
    [SerializeField] private float bpm;
    [SerializeField] private float[] lanePosX;
    [SerializeField] private Text scoreLabel, postGameScoreLabel;
   

    [SerializeField] private NoteInfo[] noteList;

    [SerializeField] public GameObject confettiParticle;

    private float beatLength;
    private bool playingMusic, gameOver;
    private AudioSource audioSource;
    private int score;

    

    void Start()
    {
       
        audioSource = gameObject.GetComponent<AudioSource>();
        postGameUI.SetActive(false);
        PLacingNotes();
        Invoke("postGameScreen", startDelay + audioSource.clip.length);
    }


    void Update()
    {
        if (!playingMusic && Time.time >= startDelay)
        {
            audioSource.Play();
            playingMusic = true;
            Debug.Log(Time.time);
        }
        
        scoreLabel.text = score.ToString();
    }

    private void PLacingNotes()
    {
        beatLength = 60 / bpm;
        foreach (NoteInfo note in noteList)
        {
            float noteXpos = lanePosX[note.lane - 1];
            //The distance between notes     +   The distance from buttons
            float noteZpos = (note.beatNumber * beatLength * noteSpeed) + (startDelay * noteSpeed);
            GameObject newNote = Instantiate(note.noteType, transform.position + new Vector3(noteXpos, 0.6f, noteZpos), Quaternion.identity, gameObject.transform);
            //newNote.transform.localRotation = gameObject.transform.rotation;
            newNote.GetComponent<Note>().speed = noteSpeed;
        }
    }

    public void addScore(int noteValue)
    {
        score += noteValue;
    }

    private void postGameScreen()
    {
        inGameUI.SetActive(false);
        postGameScoreLabel.text = "Your Score: " + score;
        Instantiate(confettiParticle, new Vector3(5.30999994f, 10, -95.4400024f), Quaternion.identity);
        Instantiate(confettiParticle, new Vector3(16,14, -95.4400024f), Quaternion.identity);
        Instantiate(confettiParticle, new Vector3(20,14, -95.4400024f), Quaternion.identity);
        Instantiate(confettiParticle, new Vector3(29.0200005F, 10, -95.4400024f), Quaternion.identity);


        postGameUI.SetActive(true);
      
        

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);

    }
}

[Serializable]
public struct NoteInfo
{
    public int beatNumber, lane;
    public GameObject noteType;   
}

