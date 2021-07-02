using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapPlacement : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    private ARRaycastManager raycastManager;

    private Pose placementPose;
    private bool isPlacementPoseValid = false;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementPlanePosition();

        bool isValidTouch = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        if (isPlacementPoseValid && isValidTouch)
        {
            Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        }
    }

    private void UpdatePlacementPose()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        isPlacementPoseValid = hits.Count > 0;
        if (isPlacementPoseValid)
        {
            placementPose = hits[0].pose;
            
            var cameraForward = Camera.current.transform.forward;
            var placementRotation = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(placementRotation);
        }
    }

    private void UpdatePlacementPlanePosition()
    {
        if (isPlacementPoseValid)
        {   
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
}
