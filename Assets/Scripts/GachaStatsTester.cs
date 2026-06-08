using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaStatsTester : MonoBehaviour
{

    [SerializeField] private int simulatedPulls;
    [SerializeField] private GachaCalculator gacha;
    private int currentPitySR = 0;
    private int currentPitySSR = 0;
    private float totalSRPity = 0;
    private int numSR = 0;
    private float totalSSRPity = 0;
    private int numSSR = 0;
    private string currentRoll;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("pitySR", 0);
        PlayerPrefs.SetInt("pitySSR", 0);
    }

    void Awake()
    {
        SimulateRolls();
    }

    void SimulateRolls()
    {
        for (int i = 0; i < simulatedPulls; i++)
        {
            currentRoll = gacha.Pull();
            if (currentRoll.Contains("ssr"))
            {
                totalSSRPity = totalSSRPity + currentPitySSR;
                numSSR++;
                currentPitySSR = 0;
                currentPitySR++;
            }
            else if (currentRoll.Contains("sr"))
            {
                totalSRPity = totalSRPity + currentPitySR;
                numSR++;
                currentPitySR = 0;
                currentPitySSR++;
            }
            else
            {
                currentPitySR++;
                currentPitySSR++;
            }
        }

        Debug.Log("Results of " + simulatedPulls + " pulls:");
        Debug.Log("Total SSR: " + numSSR + "\nWith average pity: " + (totalSSRPity / numSSR));
        Debug.Log("Total SR: " + numSR + "\nWith average pity: " + (totalSRPity / numSR));
    }
}
