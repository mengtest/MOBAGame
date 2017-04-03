﻿using System.Collections;
using System.Collections.Generic;
using Common.DTO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 好友列表的界面
/// TODO 这里少一个删除好友的功能 懒得写了
/// </summary>
public class FriendListPanel : UIBasePanel
{
    [SerializeField]
    private GameObject ItemFriend;

    [SerializeField]
    private Transform GridLayout;

    // 保存好友列表
    private List<FriendItem> m_friendList = new List<FriendItem>();

    void Start()
    {
        List<DtoFriend> friends = GameData.player.Friends;
        GameObject go = null;
        foreach (DtoFriend friend in friends)
        {
            go = Instantiate(ItemFriend);
            go.transform.SetParent(GridLayout);
            FriendItem item = go.GetComponent<FriendItem>();
            item.SetItem(friend.Name, friend.IsOnline);

            m_friendList.Add(item);
        }
    }

    /// <summary>
    /// 添加好友项
    /// </summary>
    /// <param name="friend"></param>
    public void AddFriend(DtoFriend friend)
    {
        GameObject go = null;
        go = Instantiate(ItemFriend);
        go.transform.SetParent(GridLayout);
        FriendItem item = go.GetComponent<FriendItem>();
        item.SetItem(friend.Name, friend.IsOnline);

        m_friendList.Add(item);
    }

    /// <summary>
    /// 更新好友状态
    /// </summary>
    public void UpdateFriendItem(DtoFriend friend)
    {
        foreach (FriendItem item in m_friendList)
        {
            if (item.Name == friend.Name)
            {
                item.SetOnline(friend.IsOnline);
                return;
            }
        }
    }
}
