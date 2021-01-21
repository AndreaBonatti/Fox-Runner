using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float startingAnimationDuration = 2.0f;
    private Vector3 animationCameraOffset = new Vector3(0, 5, 5);

    void Update()
    {
        moveVector = player.position + offset;
        // Restriction on X and Y movement of the camera
        moveVector.x = 0;
        moveVector.y = 2;

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationCameraOffset, moveVector, transition);
            transition += Time.deltaTime * (1 / startingAnimationDuration);
            // Rotation of the camera to look always the fox
            Vector3 target = new Vector3(0.0f, player.position.y, player.position.z);
            transform.LookAt(target);
        }
    }
}
