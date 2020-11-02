using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public AudioClip musica1;
    public AudioClip musica2;
    public AudioClip musica3;
    public AudioClip musica4;

    public AudioSource audioSource;

    public GameObject body1;
    public GameObject body2;
    public GameObject body21;
    public GameObject body3;

    public Image imgProgress;
    float tempo;

    public List<GameObject> arrGameObjs;


    public List<GameObject> arrGameObjs2;

    private bool isCoroutineExecuting = false;
    private bool isPlaying = false;

    public void Answer1()
    {
        if (isCoroutineExecuting)
            return;
        arrGameObjs.ForEach(x => x.SetActive(false));
        arrGameObjs.OrderBy(x => Guid.NewGuid()).FirstOrDefault().SetActive(true);
        StartCoroutine(ExecuteAfterTime(3f, () =>
        {
            body2.SetActive(false);
            body21.SetActive(true);
        }));
    }

    public void Answer2()
    {
        if (isCoroutineExecuting)
            return;
        arrGameObjs2.ForEach(x => x.SetActive(false));
        arrGameObjs2.OrderBy(x => Guid.NewGuid()).FirstOrDefault().SetActive(true);
        StartCoroutine(ExecuteAfterTime(3f, () =>
        {
            body21.SetActive(false);
            body3.SetActive(true);
        }));
    }

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }


    public void PlaySound()
    {
        imgProgress.fillAmount = 0;
        tempo = 0;
        audioSource.clip = musica1;
        audioSource.Play();
        isPlaying = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if (tempo > 30)
        {
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
                body1.SetActive(false);
                body2.SetActive(true);
            }
        }
        else
        {
            if (isPlaying)
            {
                imgProgress.fillAmount = (tempo / 30f);
            }
        }
    }
}
