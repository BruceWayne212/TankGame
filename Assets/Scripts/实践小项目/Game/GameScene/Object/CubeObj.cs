using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //奖励预设体 关联
    public GameObject[] rewardObjects;
    //死亡特效预设体关联
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        //1.设置好障碍物标签 cube子弹会自动移除
        //2.打到自己创建随机奖励的逻辑
        //随机一个数据来获取奖励
        int rangeInt = Random.Range(0, 100);
        //50%的概率 创建一个奖励
        if (rangeInt < 50)
        {
            //随机创建一个 奖励预设体 在当前位置
            rangeInt = Random.Range(0, rewardObjects.Length);
            //放到当前箱子所在位置即可
            Instantiate(rewardObjects[rangeInt], this.transform.position, this.transform.rotation);
        }
        //创建特效预设体
        GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
        //控制音效
        AudioSource audioS = effObj.GetComponent<AudioSource>();
        audioS.volume = GameDataMgr.Instance.musicData.soundValue;
        audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        Destroy(this.gameObject);
    }
}
