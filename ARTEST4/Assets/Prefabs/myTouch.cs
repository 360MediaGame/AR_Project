using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class myTouch : MonoBehaviour
{
    public ARRaycastManager arRaycaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjectByTouch();
    }

    private void PlaceObjectByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.All)) // ��¶�� �浹�ϸ�
            {
                Pose hitPose = hits[0].pose;        // ù��° hits�� �Ͼ ��ü�� position���� ����

                gameObject.transform.position = hitPose.position;
                gameObject.transform.rotation = hitPose.rotation;

            }
        }
    }
}
