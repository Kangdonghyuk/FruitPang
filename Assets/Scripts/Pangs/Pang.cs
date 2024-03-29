﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pang : MonoBehaviour
{
    SpriteRenderer spRenderer;
    Rigidbody2D rigid;
    bool isFollowing;
    bool isActive, isMenu;
    public int type;
    int id;

    // Start is called before the first frame update
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {   
        transform.position = new Vector3(10.0f, 10.0f, 0f);
        rigid.simulated = false;
        isFollowing = false;
        isActive = false;
        isMenu = false;
        type = -1;
        id = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0.0f)
            return ;

        if(!isActive)
            return ;

        if(isMenu) {
            float menuY = transform.position.y;
            if(menuY <= -5.0f)
                Destroy(gameObject);
            return ;
        }

        if(isFollowing) {
            rigid.velocity = Vector3.zero;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3.forward * 10);
        }

        float x = transform.position.x, y = transform.position.y;
        if(Mathf.Abs(x) >= 2.3f || y >= 3.87 || y <= -4.25f)
            isFollowing = false;
        if(Mathf.Abs(x) >= 2.58f || y >= 4.5f || y <= -4.8f) {
            isFollowing = false;
            PangCreator.I.SelfDestroy(id);
        }
    }

    public int Create(int id) {
        rigid.simulated = true;
        rigid.velocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(-2.08f, 2.09f), 4.0f, 0f);

        this.id = id;
        type = (int)Random.Range(0, PangInfo.TYPE_MAX);
        //spRenderer.color = PangInfo.colorList[type];

        spRenderer.sprite = PangInfo.pangImageList[type];

        isActive = true;

        return type;
    }
    public int Create(int id, float posY) {
        rigid.simulated = true;
        rigid.velocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(-2.08f, 2.09f), posY, 0f);

        this.id = id;
        type = (int)Random.Range(0, PangInfo.TYPE_MAX);
        //spRenderer.color = PangInfo.colorList[type];

        spRenderer.sprite = PangInfo.pangImageList[type];

        isActive = true;
        isMenu = true;

        return type;
    }

    public void Destroy() {
        rigid.simulated = false;
        transform.position = new Vector3(10.0f, 10.0f, 0f);
        isFollowing = false;
        isActive = false;
    }

    void OnMouseDown() {
        isFollowing = true;

    }
    void OnMouseUp() {
        isFollowing = false;
        rigid.velocity = Vector3.zero;
    }
}
