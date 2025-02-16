using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;

    private int score = 0;
    private GameObject pinObjects;

    void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
                Destroy(child.gameObject);
            Destroy(pinObjects);
        }

        pinObjects = Instantiate(pinCollection, pinAnchor.position, Quaternion.identity);
        foreach (FallTrigger pin in pinObjects.GetComponentsInChildren<FallTrigger>())
            pin.OnPinFall.AddListener(IncrementScore);
    }
}
