using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> cameraTargets;
    public List<Transform> followTargets;

    public Vector3 Offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;

    public float zoomLimiter;

    private Vector3 velocity;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        followTargets.AddRange(cameraTargets);
    }

    // Update is called once per frame after Update
    void LateUpdate()
    {
        MoveCamera();
        ZoomCamera();
    }

    void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void ZoomCamera()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        Bounds bounds = new Bounds(followTargets[0].position, Vector3.zero);
        foreach (Transform target in followTargets)
        {
            bounds.Encapsulate(target.transform.position);
        }
        return Mathf.Sqrt((bounds.size.x * bounds.size.x) + (bounds.size.z * bounds.size.z));
    }
    private Vector3 GetCenterPoint()
    {
        Bounds bounds = new Bounds(followTargets[0].position, Vector3.zero);

        foreach(Transform target in followTargets)
        {
            bounds.Encapsulate(target.transform.position);
        }

        return bounds.center;
    }
    private void ManageFollowTwob(int control)
    {
        if (control <= 0)
        {
            Transform twoBTransform = followTargets.Find(ch => ch.TryGetComponent(out TwoB tB));

            if (twoBTransform != null)
            {
                followTargets.Remove(twoBTransform);
            }           
        }
        else if(control > 0 && !followTargets.Exists(tar => tar.TryGetComponent(out TwoB tB)))
        {
            followTargets.Add(cameraTargets.Find(tar => tar.TryGetComponent(out TwoB tB)));
        }
    }

    public void OnEnable()
    {
        TwoB.OnSelfControlChanged += ManageFollowTwob;
    }

    public void OnDisable()
    {
        TwoB.OnSelfControlChanged -= ManageFollowTwob;
    }
}
