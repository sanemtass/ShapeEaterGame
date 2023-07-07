using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public Pacman pacman;
    public int currentMission = 1;
    public AudioClip missionChangeSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            pacman = FindObjectOfType<Pacman>();
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public int[] GetActiveObjectTypes()
    {
        int[] activeObjectTypes;

        switch (currentMission)
        {
            case 1:
                activeObjectTypes = new int[] { 0, 3 }; // circle and obstacle
                break;
            case 2:
                activeObjectTypes = new int[] { 1, 3 }; // square and obstacle
                break;
            case 3:
                activeObjectTypes = new int[] { 2, 3 }; // hexagon and obstacle
                break;
            default:
                activeObjectTypes = new int[] { };
                break;
        }

        Debug.Log("Active object types: " + string.Join(", ", activeObjectTypes));

        return activeObjectTypes;
    }

    public void NextMission()
    {
        currentMission++;
        pacman.ResetScore();
        UIManager.Instance.UpdateScore(pacman.score);

        if (currentMission == 4 && pacman.score >= 5)
        {
            GameManager.Instance.EndGame();
        }
        else
        {
            if (currentMission <= 3)
            {
                UIManager.Instance.UpdateMission();

                audioSource.PlayOneShot(missionChangeSound);
            }
        }
    }
}
