using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimatedLoadingText : MonoBehaviour
{
    //private vars
    [SerializeField] private Text loadCopyText;
    [SerializeField] string baseLoadingText = "Loading";
    [SerializeField] string punctuation = ".";
    [SerializeField] int max_punctuation = 3;
    [SerializeField] float timeBetweenPeriods;

    int periodIndex;

    //Properties

    //Public Methods

    //Unity Lifecycle
    private void OnEnable()
    {
        StartCoroutine(LoadTextCycle());
    }

    private void OnDisable()
    {
        StopCoroutine(LoadTextCycle());
    }

    //Private Helper Methods
    private IEnumerator LoadTextCycle()
    {
        periodIndex++;
        if(periodIndex > max_punctuation) {
            periodIndex = 0;
        }

        loadCopyText.text = baseLoadingText;

        for(int i = 0; i < periodIndex; i++) {
            loadCopyText.text += ". ";
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(LoadTextCycle());
    }
}
