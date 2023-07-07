using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject celebrationPanel;
    public ParticleSystem confettiParticles;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        celebrationPanel.SetActive(true);

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        confettiParticles.Play();

        Invoke("StopTime", 1.5f);
    }

    private void StopTime()
    {
        Time.timeScale = 0f;
    }
}
