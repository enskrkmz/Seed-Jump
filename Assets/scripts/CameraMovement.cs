using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float followSpeed;
    [SerializeField] private TMP_Text scoreText;
    private int score;
    private void Update()
    {
        score = Mathf.RoundToInt(transform.position.y);
        scoreText.text = score.ToString();
    }
    private void LateUpdate()
    {
        Vector3 distance = Vector3.Lerp(transform.position, playerTransform.position,followSpeed * Time.deltaTime);
        if (transform.position.y < playerTransform.position.y)
        {
            transform.position = new Vector3(transform.position.x, distance.y, transform.position.z);
        }
    }
}
