using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    public GameObject[] shapes; // Bu, Pacman'in dönüştürülebileceği şekillerin listesidir.
    public AudioClip shapeChangeSound; // Şekil değiştirme sesi.
    public MissionManager missionManager;
    public int currentShape = 0; // Bu, şu anki aktif olan şeklin index'idir.

    private AudioSource audioSource; // Sesleri çalmak için kullanılan AudioSource.
    private int score = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        missionManager = MissionManager.Instance;
    }

    void ChangeShape(int newShapeIndex)
    {
        // Eğer yeni şekil currentMission-1. indekste değilse...
        if (newShapeIndex != missionManager.currentMission - 1)
        {
            // Sallanma animasyonu başlat
            float duration = 0.5f; // Sallanmanın süresi.
            Vector3 strength = new Vector3(1f, 1f, 0f); // Sallanmanın gücü.
            int vibrato = 10; // Sallanmanın hızı.

            transform.DOShakePosition(duration, strength, vibrato);
        }
        else // Eğer yeni şekil currentMission-1. indeksteyse...
        {
            // ...sesi çal.
            audioSource.PlayOneShot(shapeChangeSound);

            score++;
            UIManager.Instance.UpdateScore(score);

            // Eğer skor 5'e ulaştıysa...
            if (score >= 5)
            {
                MissionManager.Instance.NextMission();
            }
        }

        // Pacman'in şeklini değiştir.
        shapes[currentShape].SetActive(false); // Eski şekli devre dışı bırak.
        shapes[newShapeIndex].SetActive(true); // Yeni şekli aktif hale getir.

        // Şimdi yeni şekil aktif şekil oldu.
        currentShape = newShapeIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shape collidedShape = collision.gameObject.GetComponent<Shape>();
        Obstacle collidedObstacle = collision.gameObject.GetComponent<Obstacle>();

        if (collidedShape != null) // Eğer çarpıştığımız obje bir şekil ise...
        {
            ChangeShape(collidedShape.type); // ...şekli değiştir.
        }
        // Eğer çarpıştığımız obje bir engel ise...
        else if (collidedObstacle != null)
        {
            // "duration" saniye boyunca, "strength" gücünde ve "vibrato" hızında salla.
            float duration = 0.5f; // Sallanmanın süresi.
            Vector3 strength = new Vector3(1f, 1f, 0f); // Sallanmanın gücü.
            int vibrato = 10; // Sallanmanın hızı.

            transform.DOShakePosition(duration, strength, vibrato);
        }
    }

    public void ResetScore()
    {
        score = 0;
        UIManager.Instance.UpdateScore(score);
    }

}
