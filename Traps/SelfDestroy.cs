using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DestroyOBJ());
    }

    IEnumerator DestroyOBJ()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
