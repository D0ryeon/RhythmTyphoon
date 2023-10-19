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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(PlayClearAnimation));
    }

    IEnumerator PlayClearAnimation()
    {
        vtuberAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        clearTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        resultTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        scoreTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        scoreAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        comboTextAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        comboAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        continueTextAnimation.SetTrigger("Play");
    }
}