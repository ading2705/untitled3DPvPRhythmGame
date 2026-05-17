using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GachaCalculator : MonoBehaviour
{

    [Header("Items")]
    [SerializeField] private string[] gachaItemSSR;
    [SerializeField] private string[] gachaItemSR;
    [SerializeField] private string[] gachaItemR;

    [Header("Rarities")]
    [SerializeField] private float raritySSR;
    [SerializeField] private float raritySR;
    [SerializeField] private int pitySSR;
    [SerializeField] private int pitySR;

    private int currentPitySSR;
    private int currentPitySR;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsTrue(gachaItemR.Length > 0);
        Assert.IsTrue(gachaItemSR.Length > 0);
        Assert.IsTrue(gachaItemSSR.Length > 0);
        Assert.IsTrue(raritySR > 0);
        Assert.IsTrue(raritySR < 1);
        Assert.IsTrue(raritySSR > 0);
        Assert.IsTrue(raritySSR < 1);
        Assert.IsTrue(raritySR > raritySSR);
        Assert.IsTrue(pitySR > 0);
        Assert.IsTrue(pitySSR > 0);
        Assert.IsTrue(pitySR < pitySSR);
    }

    public int GetCurrentPity()
    {
        return PlayerPrefs.GetInt("pitySSR");
    }

    string GetPull(string[] itemList)
    {
        return itemList[(int)Random.Range(0, itemList.Length)];
    }

    public string Pull()
    {
        currentPitySSR = PlayerPrefs.GetInt("pitySSR");
        currentPitySR = PlayerPrefs.GetInt("pitySR");
        if (currentPitySSR >= pitySSR)
        {
            PlayerPrefs.SetInt("pitySSR", 0);
            PlayerPrefs.SetInt("pitySR", currentPitySR + 1);
            return GetPull(gachaItemSSR);
        }
        else if (currentPitySR >= pitySR)
        {
            PlayerPrefs.SetInt("pitySR", 0);
            PlayerPrefs.SetInt("pitySSR", currentPitySSR + 1);
            return GetPull(gachaItemSR);
        }
        float pullVal = Random.Range(0f, 100f);
        if (pullVal < raritySSR)
        {
            PlayerPrefs.SetInt("pitySSR", 0);
            PlayerPrefs.SetInt("pitySR", currentPitySR + 1);
            return GetPull(gachaItemSSR);
        }
        else if (pullVal < raritySR + raritySSR)
        {
            PlayerPrefs.SetInt("pitySR", 0);
            PlayerPrefs.SetInt("pitySSR", currentPitySSR + 1);
            return GetPull(gachaItemSR);
        }
        else
        {
            PlayerPrefs.SetInt("pitySR", currentPitySR + 1);
            PlayerPrefs.SetInt("pitySSR", currentPitySSR + 1);
            return GetPull(gachaItemR);
        }
    }
}
