using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public Pacman pacman;
    public int currentMission = 1;

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
    }

    public int[] GetActiveObjectTypes()
    {
        int[] activeObjectTypes;

        switch (currentMission)
        {
            case 1:
                activeObjectTypes = new int[] { 0, 3 }; // Üçgen ve engel
                break;
            case 2:
                activeObjectTypes = new int[] { 1, 3 }; // Kare ve engel
                break;
            case 3:
                activeObjectTypes = new int[] { 2, 3 }; // Altıgen ve engel
                break;
            default:
                activeObjectTypes = new int[] { }; // Geçersiz görev
                break;
        }

        Debug.Log("Active object types: " + string.Join(", ", activeObjectTypes));

        return activeObjectTypes;
    }

    public void NextMission()
    {
        currentMission++;
        pacman.ResetScore();
        UIManager.Instance.UpdateMission();
    }

}

