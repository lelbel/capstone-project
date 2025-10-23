using System.Collections;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    private TouchControls controls;
    private Coroutine zoomCoroutine;
    private Transform cameraTransform;
    [SerializeField] private float cameraSpeed = 4;

    private void Awake()
    {
        //  instantiate touch controls
        controls = new TouchControls();

        //  make sure camera is tagged as main
        cameraTransform = Camera.main.transform;
    }

    //  enable controls when script is enabled
    private void OnEnable()
    {
        controls.Enable();
    }

    //  disable controls when script is disabled
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        //  second finger press down starts
        controls.Touch.SecondaryTouchContact.started += _ => ZoomStart();

        //  second finger press down ends
        controls.Touch.SecondaryTouchContact.canceled += _ => ZoomEnd();
    }

    //  start zoom    
    private void ZoomStart()
    {
        Debug.Log("coroutine start");
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    //  end zoom
    private void ZoomEnd()
    {
        Debug.Log("coroutine end");
        StopCoroutine(zoomCoroutine);
    }

    //  stops execution of the function depending on specified condition (keeps update function cleaner)
    IEnumerator ZoomDetection()
    {
        //  track previous position of fingers and compare to current position (comparing distances)
        float previousDistance = 0f;
        float distance = 0f;

        while (true)
        {
            //  measure current distance between primary and secondary fingers
            distance = Vector2.Distance(controls.Touch.PrimaryFingerPosition.ReadValue<Vector2>(), controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());

            //  detection
            //  zoom out (distance larger than previous distance)
            if (distance > previousDistance)
            {
                Debug.Log("zoom out");
                //  move camera back
                Vector3 targetPosition = cameraTransform.position;
                targetPosition.z -= 1;
                cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPosition, Time.deltaTime * cameraSpeed);
            }

            //  zoom in (distance smaller than previous distance)
            else if (distance < previousDistance)
            {
                Debug.Log("zoom in");
                //  move camera forward
                Vector3 targetPosition = cameraTransform.position;
                targetPosition.z += 1;
                cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPosition, Time.deltaTime * cameraSpeed);
            }

            //  track previous distance for next iteration
            previousDistance = distance;

            //  ensure that coroutine waits until next frame to continue the while loop
            yield return null;
        }
    }
}
