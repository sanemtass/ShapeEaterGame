using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Diğer scriptlerden erişebilmek için static bir instance.

    public TextMeshProUGUI scoreText; // Skoru göstermek için kullanılan Text component.
    public TextMeshProUGUI missionText;

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

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score; // Skoru güncelle.
    }

    public void UpdateMission()
    {
        int currentMission = MissionManager.Instance.currentMission; // Mevcut görevi al.

        // Görev için gereken şekli al.
        GameObject requiredShapeObject = ObjectPooling.Instance.GetPoolObject(currentMission - 1);
        Shape requiredShape = requiredShapeObject.GetComponent<Shape>();
        string shapeName = requiredShape.name;

        // Görev metnini güncelle.
        missionText.text = "Mission " + currentMission + ": Collect 5 " + shapeName + "s!";
    }

}
