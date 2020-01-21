using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using DG.Tweening;

public class InfoManager : MonoBehaviour
{
    [SerializeField] private Sprite[] signatureSprites;
    [SerializeField] private Sprite[] artistsSprites;
    [SerializeField] private Image[] imagePlaceholders;
    [SerializeField] private Text[] textRegions;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject selector;
    private bool activePanel = false;
    private JsonData data;
    void Start()
    {
        TextAsset file = Resources.Load("texts") as TextAsset;
        string content = file.ToString();
        data = JsonMapper.ToObject(content);
        Debug.Log(data[0]["name"]);


        infoPanel.SetActive(false);
        closeButton.onClick.AddListener(ClosePanel);
        // jsonString = File.ReadAllText(Application.dataPath + "/Resources/Languatexts.json");
        // jsonString = Resources.Load<TextAsset>("texts.json");
        // texts = JsonMapper.ToObject(jsonString);
        // Debug.Log(texts);
        // Debug.Log(jsonString);



        TexturesAnimations.current.onAnimFinished += OpenPanel;
    }

    void OpenPanel(int index)
    {
        if (!activePanel)
        {
            infoPanel.SetActive(true);
            selector.SetActive(false);
            activePanel = true;

            imagePlaceholders[0].sprite = signatureSprites[index];
            imagePlaceholders[1].sprite = artistsSprites[index];
            for (int i = 0; i < imagePlaceholders.Length; i++)
            {
                // DOTween.ToAlpha(() => imagePlaceholders[i].color, x => imagePlaceholders[i].color = x, 1, 0.5f);
            }

            textRegions[0].text = (string)data[index]["name"];
            textRegions[1].text = (string)data[index]["subName"];
            textRegions[2].text = (string)data[index]["text"];
        }
    }

    void ClosePanel()
    {
        infoPanel.SetActive(false);
        selector.SetActive(true);
        activePanel = false;
        // DOTween.ToAlpha(() => imagePlaceholders.color, x => imagePlaceholders.color = x, 0, 0.5f);

    }
}
