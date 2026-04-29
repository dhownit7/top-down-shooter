using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour
{
    public float flashTime = 0.05f;

    public void Flash()
    {
        gameObject.SetActive(true);
        StartCoroutine(HideFlash());
    }

    IEnumerator HideFlash()
    {
        yield return new WaitForSeconds(flashTime);
        gameObject.SetActive(false);
    }
}