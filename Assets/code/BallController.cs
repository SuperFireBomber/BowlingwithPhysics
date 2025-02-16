using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    private bool isBallLaunched;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        ResetBall();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    public void LaunchBall()
    {
        if (isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.SetParent(ballAnchor);
        transform.position = ballAnchor.position;
        transform.rotation = ballAnchor.rotation;
        transform.localPosition = Vector3.zero;
    }
}
