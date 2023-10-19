using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundsSurvived : MonoBehaviour
{
    public TMP_Text roundTxt;
    void Awake ()
    {
        StartCoroutine(AnimateText());
    }
    IEnumerator AnimateText ()
    {
        roundTxt.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);
        while(round < PlayerStats.Rounds)
        {
            round++;
            roundTxt.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }

    }
}
