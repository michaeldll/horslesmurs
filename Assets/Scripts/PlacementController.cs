using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementController : MonoBehaviour
{

    [SerializeField] private GameObject petiteGaleriePrefab;
    [SerializeField] private GameObject CTAs;
    [SerializeField] private GameObject FindSignature;
    [SerializeField] private Animation FindSignatureAnimation;
    private GameObject currentGalerie;
    private int frames = 0;
    private bool findFlag = false;
    [SerializeField] private GameObject ScenePlacer;
    private GameObject CursorLayout;


    [SerializeField]
    private Texture[] ScenePlacerTextures;
    private ARRaycastManager arRaycastManager;
    private Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

    private bool rayFlag = true;
    private bool ScenePlaced = false;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        CTAs.SetActive(true);
        FindSignature.SetActive(false);
        ScenePlacer.SetActive(false);

    }


    void Start()
    {
        currentGalerie = Instantiate(petiteGaleriePrefab);
        Debug.Log("heuu");
        currentGalerie.SetActive(false);
        currentGalerie.transform.Find("CursorLayout").GetChild(1).GetComponent<Button>().onClick.AddListener(ReplaceScene);

    }

    void Update()
    {

        if (ScenePlaced)
            return;

        Material PlaneMaterial = ScenePlacer.GetComponent<Renderer>().material;
        PlaneMaterial.mainTexture = ScenePlacerTextures[1];
        if (arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;
            ScenePlacer.transform.position = hitPos.position;
            ScenePlacer.transform.rotation = hitPos.rotation;
            PlaneMaterial.mainTexture = ScenePlacerTextures[0];
            ScenePlacer.SetActive(true);


            if (Input.touchCount > 0 && rayFlag == true)
            {
                rayFlag = false;
                Debug.Log("it works");
                CTAs.SetActive(false);
                ScenePlacer.SetActive(false);
                findFlag = true;
                currentGalerie.SetActive(true);
                currentGalerie.transform.position = hitPos.position;
                currentGalerie.transform.rotation = hitPos.rotation;
                ScenePlaced = true;
                FindSignature.SetActive(true);

            }
            else
            {
                rayFlag = true;
            }

        }

    }

    void ReplaceScene()
    {
        ScenePlacer.SetActive(true);
        // CursorLayout.SetActive(false);
        currentGalerie.SetActive(false);
        ScenePlaced = false;
    }

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
}
