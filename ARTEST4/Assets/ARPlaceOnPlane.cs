using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject placeObject;

    GameObject spawnObject;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCenterObject();
        PlaceObjectByTouch();
        Move();
    }

    void Move()
    {
        if (!spawnObject)
            return;
        if (animator.GetBool("isSelect"))
            return;
        
        animator.SetBool("isMove", true);

        //spawnObject.transform.position.x = spawnObject.transform.position.x + (2 * Time.deltaTime);
    }

    void PlaceObjectByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if (!spawnObject)
                {
                    spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
                    spawnObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                    animator = spawnObject.GetComponent<Animator>();
                }
                else
                {
                    spawnObject.transform.position = hitPose.position;
                    spawnObject.transform.rotation = hitPose.rotation;

                    animator.SetBool("isMove", false);               
                    animator.SetBool("isSelect", true); 
                }
            }
        }
        else
        {
            if (spawnObject)
                animator.SetBool("isSelect", false); 
        }
    }
    private void UpdateCenterObject()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycaster.Raycast(screenCenter, hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            Pose placementPose = hits[0].pose;
            placeObject.SetActive(true);
            placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placeObject.SetActive(false);
        }
    }
}
