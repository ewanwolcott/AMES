using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveBackground : MonoBehaviour
{
    float startPos, length;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distance = (cam.transform.position.x * parallaxEffect); // 0 = moves with the camera, 1 = does not move
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(movement > startPos + length) startPos += length;
        else if(movement < startPos - length) startPos -= length;
    }

    // This script is used to create a parallax effect for the background. The background will move at a different speed than the camera, creating a sense of depth. The lag amount can be adjusted to increase or decrease the parallax effect. A lag amount of 0 means the background will move at the same speed as the camera, while a lag amount of 1 means the background will not move at all.
    /*[SerializeField][Range(0f, 1f)] float _lagAmount = 0f;

    Vector3 _previousCameraPosition;
    Transform _camera;
    Vector3 _targetPosition;
    float _parallaxAmount;

    float ParallaxAmount => 1f - _lagAmount;

    private void Awake()
    {
        _camera = Camera.main.transform;
        _previousCameraPosition = _camera.position;
    }

    private void LateUpdate()
    {
        Vector3 movement = CameraMovement;
        if (movement == Vector3.zero) return;
        _targetPosition = new Vector3(transform.position.x + movement.x * ParallaxAmount, transform.position.y, transform.position.z);
        transform.position = _targetPosition;
    }

    Vector3 CameraMovement
    {
        get
        {
            Vector3 movement = _camera.position - _previousCameraPosition;
            _previousCameraPosition = _camera.position;
            _parallaxAmount = ParallaxAmount;
            return movement;
        }
    }*/
}

