using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DifficultyChanger : MonoBehaviour
{
    private float _difficulty = 1;

    public static DifficultyChanger Instance;

    public Action<float> OnDifficultyChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        StartCoroutine(DifficultyCycle());
    }

    private IEnumerator DifficultyCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _difficulty++;
            OnDifficultyChanged?.Invoke(_difficulty);
        }
    }
}
