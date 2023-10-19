using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropType
{
    //加属性的4种类型
    Atk,
    Def,
    MaxHp,
    Hp,
}
public class PropRewardWeapon : MonoBehaviour
{
    public E_PropType type = E_PropType.Atk;
    //默认添加的值 获取道具后
    public int changeValue = 2;
    //获取特效
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        //只有玩家才能拾取
        if (other.CompareTag("Player")) {
            //得到对应的玩家脚本
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            //根据类型来添加属性
            switch (type)
            {
                case E_PropType.Atk:
                    playerObj.atk += changeValue;
                    break;
                case E_PropType.Def:
                    playerObj.def += changeValue;
                    break;
                case E_PropType.Hp:
                    playerObj.hp += changeValue;
                    //加血不能超过上线
                    if (playerObj.hp > playerObj.maxHp)
                        playerObj.hp = playerObj.maxHp;
                    //更新血条
                    GamePanel.Instance.UpdateHP(playerObj.maxHp, playerObj.hp);
                    break;
                case E_PropType.MaxHp:
                    playerObj.maxHp += changeValue;
                    //更新血条
                    GamePanel.Instance.UpdateHP(playerObj.maxHp, playerObj.hp);
                    break;
            }
            //播放一个奖励特效
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //控制获取音效
            AudioSource audioS = eff.GetComponent<AudioSource>();
            //大小和开启状态
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            Destroy(this.gameObject);
        }

    }

}
