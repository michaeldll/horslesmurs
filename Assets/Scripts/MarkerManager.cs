using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MarkerManager : MonoBehaviour
{

    private ARTrackedImageManager _arTrackedImageManager;
    public event Action onMarkerFound;
    public static MarkerManager current;
    private bool markerFlag = false;
    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        // _arTrackedImageManager.trackedImagesChanged += onChange;
    }

    void onChange(ARTrackedImagesChangedEventArgs arg)
    {
        if (markerFlag) return;
        onMarkerFound();
        markerFlag = true;
    }
}
