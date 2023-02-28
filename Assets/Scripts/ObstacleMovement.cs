using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    [Header("Rotation Movement")]
    public Vector3 Rotation;
    public float Duration;
    public int LoopCount;
    public LoopType Loop;

    [Header("Left/Right Movement")]
    public Vector3 StartPos;
    public Vector3 EndPos;
    public float LRDuration;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(Rotation, Duration, RotateMode.LocalAxisAdd).SetLoops(LoopCount, Loop).SetEase(Ease.Linear);

        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMovement()
    {
        transform.DOLocalMove(EndPos, LRDuration).OnComplete(() => RestartMovement()).SetEase(Ease.Linear);
    }

    public void RestartMovement()
    {
        transform.DOLocalMove(StartPos, LRDuration).OnComplete(() => StartMovement()).SetEase(Ease.Linear);
    }
}