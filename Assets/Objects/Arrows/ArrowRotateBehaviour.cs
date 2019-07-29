﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotateBehaviour : MonoBehaviour
{
    public ArrowsRotateBehaviour controller;
    public Renderer arrowColor;
    public Maze.Direction direction;
    public bool cw;

    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var tileId = CubeBehaviour.GetSideId(CubeBehaviour.GetMoveRotation(direction, Quaternion.Inverse(controller.player.cameraWrapper.transform.localRotation)));
        arrowColor.material.color = FloorBehaviour.GetInstance().faces.GetFace(tileId).color;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            if (hit.collider == col)
                controller.Rotate(cw);
    }
}
