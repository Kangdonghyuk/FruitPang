using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangClass {
        GameObject obj;
        Pang mainScript;
        public bool isActive;
        public int type;
        public int id;
        public Vector3 position {
            get { return obj.transform.position; }
        }
        public PangClass(GameObject obj, Transform parent) {
            this.obj = obj;
            mainScript = obj.GetComponent<Pang>();
            obj.transform.SetParent(parent);
            isActive = false;
            type = -1;
            id = -1;
        }
        public void Create(int id) {
            this.id = id;
            isActive = true;
            type = mainScript.Create(id);
        }
        public void Destroy() {
            isActive = false;
            mainScript.Destroy();
        }
}

public class PangCreator : MonoBehaviour
{
    public static PangCreator I;
    AudioSource audioSource;

    void Awake() {
        I = this;

        audioSource = GetComponent<AudioSource>();
    }

    public GameObject pangPrefab;
    public GameObject pangEfectPrefab;
    public PangClass[] pangList;

    void Start()
    {
        pangList = new PangClass[PangInfo.PANG_MAX];
        for(int index = 0; index < PangInfo.PANG_MAX; index++) {
            pangList[index] = new PangClass(
                Instantiate(pangPrefab, transform.position, Quaternion.identity), transform);
        }

        StartCoroutine(CreatePang());
    }

    void Update()
    {
        
    }

    public void SelfDestroy(int id) {
        pangList[id].isActive = false;
    }
    public void Destroy(int id) {
        audioSource.Play();

        Instantiate(pangEfectPrefab, pangList[id].position, Quaternion.identity);

        pangList[id].isActive = false;
        pangList[id].Destroy();
    }

    IEnumerator CreatePang() {
        while(true) {
            yield return new WaitForSeconds(0.2f);
            for(int index = 0; index < PangInfo.PANG_MAX; index++) {
                if(pangList[index].isActive == false) {
                    pangList[index].Create(index);
                    break;
                }
            }
        }
    }
}
