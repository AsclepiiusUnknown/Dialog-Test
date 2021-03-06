﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonEffects : MonoBehaviour {

    private bool isHighlighted;
    private Vector3 regularPos;
    private Vector3 highlightedPos;
    private float currentTime;
    [SerializeField]
    private float highlightTime = 1f;
    private bool isPositionSet;

	// Use this for initialization
	void Start () {
        isHighlighted = false;
        isPositionSet = true;
        regularPos = transform.position;
        highlightedPos = transform.position + (transform.forward * -1) * 0.1f;
        currentTime = 0f;
    }
	
	void LateUpdate () {
        Debug.DrawRay(transform.position, transform.forward*-1, Color.green);
        if(isHighlighted && currentTime <= highlightTime)
        {
            /*currentTime += Time.deltaTime / highlightTime;
            float blend = Mathf.Lerp(0.0f, 0.1f, currentTime);
            transform.position += (transform.forward * -1) * 0.1f * blend;*/
            currentTime += Time.deltaTime / highlightTime;
            float stepDistance = Time.deltaTime / highlightTime;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.1f, 1.1f, 1.1f), currentTime);
            isPositionSet = false;
        }
        else if (isHighlighted && currentTime >= highlightTime && !isPositionSet)
        {
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            isPositionSet = true;
        }
        else if(!isHighlighted && currentTime <= highlightTime)
        {
            currentTime += Time.deltaTime / highlightTime;
            float stepDistance = Time.deltaTime / highlightTime;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), currentTime);
            isPositionSet = false;
        }
        else if(!isHighlighted && currentTime >= highlightTime && !isPositionSet)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isPositionSet = true;
        }
	}

    void OnDisable()
    {
        resetPosition();
    }

    public void highlightAction()
    {
        isHighlighted = true;
        currentTime = 0f;
    }

    public void unHighlightAction()
    {
        isHighlighted = false;
        currentTime = 0f;
    }

    private void resetPosition()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        isPositionSet = true;
        isHighlighted = false;
    }
}
