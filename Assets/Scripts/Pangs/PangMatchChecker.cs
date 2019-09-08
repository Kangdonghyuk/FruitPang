using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangMatchChecker : MonoBehaviour
{
    public static PangMatchChecker I;

    PangClass[] pangList;
    int[] pangChecked;
    int checkType;
    int checkedCount;

    void Awake() {
        I = this;
    }
    void Start()
    {
        pangChecked = new int[PangInfo.PANG_MAX];
        ClearArray(pangChecked, 0, pangChecked.Length);

        checkType = 0;
        checkedCount = 0;
    }
    void ClearArray(int[] list, int value, int length) {
        for(int index = 0; index < length; index++)
            list[index] = value;
    }

    void Update()
    {
        if(Time.timeScale == 0.0f)
            return ;

        pangList = PangCreator.I.pangList;

        for(int index = 0; index < PangInfo.PANG_MAX; index++) {
            checkedCount = 1;
            ClearArray(pangChecked, 0, pangChecked.Length);
            if(pangList[index].isActive == true && pangList[index].type == checkType) {
                pangChecked[index] = 1;
                CheckAround(index);
            }
 
            if(checkedCount >= 3) {
                if(Random.Range(0, 5) == 0)
                    ItemCreator.I.CreateItem();
                for(int checkedIndex = 0; checkedIndex < PangInfo.PANG_MAX; checkedIndex++) {
                    if(pangChecked[checkedIndex] == 1)
                        PangCreator.I.Destroy(checkedIndex);
                }
                GameMNG.I.AddScore(checkedCount);
                break;
            }
        }

        checkType = (checkType + 1) % PangInfo.TYPE_MAX;

        //Debug.Log(Distance(pangList[0].position, pangList[1].position));
    }

    public void Boom(Vector3 position) {
        checkedCount = 0;
        ClearArray(pangChecked, 0, pangChecked.Length);

        for(int index = 0; index < PangInfo.PANG_MAX; index++) {
            if(pangList[index].isActive == true) {
                if(IsNear(position, pangList[index].position, 1.55f) == true)
                    PangCreator.I.Destroy(index);
            }
        }

        GameMNG.I.AddScore(10);
    }

    void CheckAround(int offset) {
        for(int index = 0; index < PangInfo.PANG_MAX; index++) {
            if(pangList[index].isActive == true && pangList[index].type == checkType &&
                pangChecked[index] == 0) {
                if(IsNear(pangList[offset].position, pangList[index].position, 0.95f) == true) {
                    pangChecked[index] = 1;
                    checkedCount += 1;
                    //Debug.DrawLine (pangList[offset].position, pangList[index].position, Color.red, 1.0f);
                    CheckAround(index);
                }
             }
        }
    }

    float Distance(Vector3 offset, Vector3 compare) {
        float x, y, distance;

        x = Subtract(offset.x, compare.x);
        y = Subtract(offset.y, compare.y);

        distance = Mathf.Sqrt(x*x + y*y);
        
        return distance;
    }
    bool IsNear(Vector3 offset, Vector3 compare, float checkDistance) {
        float x, y, distance;

        x = Subtract(offset.x, compare.x);
        y = Subtract(offset.y, compare.y);

        distance = Mathf.Sqrt(x*x + y*y);

        return distance > checkDistance ? false : true;
    }

    float Subtract(float one, float two) {
        return one > two ? one - two : two - one;
    }
}
