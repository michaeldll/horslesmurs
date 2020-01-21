using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMarkerManager : MonoBehaviour
{
    public GameObject findCTA;
    void Start()
    {
        MarkerManager.current.onMarkerFound += fadeOutCTA;
    }
    void fadeOutCTA()
    {
        findCTA.SetActive(false);
    }
}
