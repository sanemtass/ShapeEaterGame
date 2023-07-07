using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    public GameObject[] shapes;
    public AudioClip shapeChangeSound;
    public MissionManager missionManager;
    public int currentShape = 0;
    public int score = 0;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        missionManager = MissionManager.Instance;
    }

    void ChangeShape(int newShapeIndex)
    {
        if (newShapeIndex != missionManager.currentMission - 1)
        {
            float duration = 0.5f;
            Vector3 strength = new Vector3(0f, .5f, 0f);
            int vibrato = 70;

            transform.DOShakePosition(duration, strength, vibrato);
        }
        else // If the new shape is currentMission-1. if it's in the index...
        {
            audioSource.PlayOneShot(shapeChangeSound);

            score++;
            Debug.Log("Score: " + score);
            UIManager.Instance.UpdateScore(score);

            // If the score reaches 5 and the current task is 3
            if (score >= 5 && missionManager.currentMission == 3)
            {
                GameManager.Instance.EndGame();
            }
            else
            {
                if (score >= 5)
                {
                    MissionManager.Instance.NextMission();
                    //UIManager.Instance.UpdateMission();
                }
            }
        }

        shapes[currentShape].SetActive(false); 
        shapes[newShapeIndex].SetActive(true); 

        currentShape = newShapeIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shape collidedShape = collision.gameObject.GetComponent<Shape>();
        Obstacle collidedObstacle = collision.gameObject.GetComponent<Obstacle>();

        if (collidedShape != null)
        {
            ChangeShape(collidedShape.type);
        }
        else if (collidedObstacle != null)
        {
            float duration = 0.5f;
            Vector3 strength = new Vector3(0f, .5f, 0f);
            int vibrato = 70;

            transform.DOShakePosition(duration, strength, vibrato);
        }
    }

    public void ResetScore()
    {
        score = 0;
        UIManager.Instance.UpdateScore(score);
    }
}