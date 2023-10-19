using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    //有多个用于武器随机的 预设体
    public GameObject[] WeaponObj;
    //获取特效
    public GameObject getEff;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //让玩家切换武器
            int index = Random.Range(0, WeaponObj.Length);
            //得到撞到玩家身上挂载的脚本 命令它切武器
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            playerObj.ChangeWeapon(WeaponObj[index]);
            //播放一个奖励特效
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //控制获取音效
            AudioSource audioS = eff.GetComponent<AudioSource>();
            //大小和开启状态
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            //获取到自己后移除自己
            Destroy(this.gameObject);
        }
    }

}
