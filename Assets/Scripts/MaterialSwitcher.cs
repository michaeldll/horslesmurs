using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    [SerializeField] private Material highLight;
    [SerializeField] private Material normalMat;
    private MeshRenderer _Selected;
    private MeshRenderer selectedObject;
    private bool rayFlag;
    void Start()
    {
        RaycastManager.current.onHitObject += ChangeMat;
    }
    void Update()
    {
        if (_Selected != null)
        {
            // _Selected.material = normalMat;
            _Selected = null;
        }

        if (selectedObject != null)
        {
            // selectedObject.material = highLight;
            // _Selected = selectedObject;
            // selectedObject = null;
        }
    }
    void ChangeMat(RaycastHit trsm)
    {
        selectedObject = trsm.transform.GetComponent<MeshRenderer>();
    }
}
