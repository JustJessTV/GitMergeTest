﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using System.Collections;

public class LobbyServerEntry : MonoBehaviour
{
    public Text serverInfoText;
    public Text slotInfo;
    public Button joinButton;

    public void Populate(MatchDesc match, MyLobbyManager lobbyManager, Color c)
    {
        serverInfoText.text = match.name;

        slotInfo.text = match.currentSize.ToString() + "/" + match.maxSize.ToString(); ;

        NetworkID networkID = match.networkId;

        joinButton.onClick.RemoveAllListeners();
        joinButton.onClick.AddListener(() => { JoinMatch(networkID, lobbyManager); });

        GetComponent<Image>().color = c;
    }

    void JoinMatch(NetworkID networkID, MyLobbyManager lobbyManager)
    {
        lobbyManager.matchMaker.JoinMatch(networkID, "", lobbyManager.OnMatchJoined);
        lobbyManager.backDelegate = lobbyManager.StopClientClbk;
        lobbyManager.isMatchmaking = true;
        lobbyManager.DisplayIsConnecting();
    }
}
