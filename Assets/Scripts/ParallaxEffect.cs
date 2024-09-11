using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//public class ParallaxEffect : MonoBehaviour
//{
//    public Camera cam;
//    public Transform followTarget;

//    // Starting position for the parallax game object
//    Vector2 startingPosition;

//    // Start Z value of the parallax game object
//    float startingZ;

//    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

//    float zDistanceFromTarget => transform.position.z - followTarget.position.z;

//    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

//    // The further the object from the player, the faster the ParallaxEffect object will move. Drag it's Z value closer to the target to make it move slower.
//    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;


//    // Start is called before the first frame update
//    void Start()
//    {
//        startingPosition = transform.position;
//        startingZ = transform.position.z;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

//        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
//    }
//}
//public class ParallaxEffect : MonoBehaviour {

//    public Camera cam;
//    public Transform subject;

//    Vector2 startPosition;
//    float startZ;

//    Vector2 travel => (Vector2)cam.transform.position - startPosition;

//    float distanceFromSubject => transform.position.z - subject.position.z;

//    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

//    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

//    public void Start() {
//        startPosition = transform.position;
//        startZ = transform.position.z;
//    }

//    public void Update() {
//        Vector2 newPos = startPosition + travel * parallaxFactor;
//        transform.position = new Vector3(newPos.x, newPos.y, startZ);
//    }

//}

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;
    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
        // Subscribe to the CameraUpdatedEvent
        CinemachineCore.CameraUpdatedEvent.AddListener(OnCameraUpdated);
    }

    private void OnDestroy()
    {
        CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCameraUpdated);
    }

    // This will be called after the camera is positioned
    void OnCameraUpdated(CinemachineBrain brain)
    {
        // Update the parallax effect based on the camera position (only affecting the X position)
        float newPosX = startPosition.x + travel.x * parallaxFactor;

        // Keep the original Y position, so it doesn't move vertically
        transform.position = new Vector3(newPosX, transform.position.y, startZ);
    }
}