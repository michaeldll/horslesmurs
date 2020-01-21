using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{

    [SerializeField] private Camera arCamera;
    // [SerializeField] private GameObject placementButton;
    public static RaycastManager current;
    public event Action<RaycastHit> onHitObject;
    private bool clickFlag = true;
    private bool newPLacementFlag = true;
    private void Awake()
    {
        current = this;
        // PlacementController.current.SelectingNewPlacement += onActiveSelector;
        // placementButton.GetComponent<Button>().onClick.AddListener(onActiveSelector);
    }

    void onActiveSelector()
    {
        newPLacementFlag = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("a ui element");
                // return;
            }
            Ray ray = arCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hits;
            if (Physics.Raycast(ray, out hits))
            {
                if (onHitObject != null)
                {
                    if (clickFlag)
                    {
                        onHitObject(hits);
                        clickFlag = false;
                    }
                }
            }
        }
        else
        {
            clickFlag = true;
        }
    }
}
