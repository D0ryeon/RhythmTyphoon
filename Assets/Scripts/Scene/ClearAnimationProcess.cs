using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAnimationProcess : MonoBehaviour
{
    [SerializeField] private Animator clearTextAnimation;
    [SerializeField] private Animator resultTextAnimation;
    [SerializeField] private Animator scoreTextAnimation;
    [SerializeField] private Animator scoreAnimation;
    [SerializeField] private Animator comboTextAnimation;
    [SerializeField] private Animator comboAnimation;
    [SerializeField] private Animator continueTextAnimation;
    [SerializeField] private Animator vtuberAnimation;
    [SerializeField] private Animator clapAnimation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(PlayClearAnimation));
    }

    IEnumerator PlayClearAnimation()
    {
        vtuberAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1.5f);
        clearTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1.0f);
        resultTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(0.5f);
        scoreTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(0.5f);
        scoreAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(0.5f);
        comboTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(0.5f);
        comboAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(0.5f);
        clapAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1.0f);
        continueTextAnimation.SetTrigger("Play");
    }
}