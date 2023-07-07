using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missionText;
    public Image shapeImage;
    public Sprite shapeImageSprite;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateMission()
    {
        if (UIManager.Instance == null)
        {
            Debug.LogError("UIManager instance is null!");
            return;
        }

        int currentMission = MissionManager.Instance.currentMission;

        GameObject requiredShapeObject = ObjectPooling.Instance.GetPoolObject(currentMission - 1);

        string shapeName;
        Sprite shapeSprite;

        if (requiredShapeObject != null)
        {
            Shape requiredShape = requiredShapeObject.GetComponent<Shape>();
            shapeName = requiredShape.shapeName;
            shapeSprite = requiredShape.shapeSprite;
        }
        else
        {
            shapeName = "No Shape";
            shapeSprite = null;
        }

        missionText.text = "Mission " + currentMission + ": Collect 5 " + shapeName + "s!";

        shapeImage.sprite = shapeSprite;
    }
}
