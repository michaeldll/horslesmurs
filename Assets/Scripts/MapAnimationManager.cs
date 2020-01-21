using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MapAnimationManager : MonoBehaviour
{

    private GameObject[] masterPieces;
    private GameObject floor;
    void Start()
    {
        MarkerManager.current.onMarkerFound += startAnimation;
    }
    void startAnimation()
    {
        masterPieces = GameObject.FindGameObjectsWithTag("masterPiece");
        floor = GameObject.Find("Floor");
        Sequence startSequence = DOTween.Sequence();
        TweenParams tParams = new TweenParams().SetEase(Ease.InOutQuad);

        for (int i = 0; i < masterPieces.Length; i++)
        {
            Vector3 initPos = masterPieces[i].transform.position;
            masterPieces[i].transform.position -= Vector3.up * 10f;
            masterPieces[i].transform.rotation = Quaternion.Euler(0, -180, 0);
            startSequence.Insert(2 + i * 0.1f, masterPieces[i].transform.DOMoveY(initPos.y, 1).SetAs(tParams));
            startSequence.Insert(2 + i * 0.1f, masterPieces[i].transform.DORotate(new Vector3(0, 0, 0), 1).SetAs(tParams));
        }

        startSequence.Play();
    }

}
