using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordManager : MonoBehaviour
{
    private DiscordController discordC;
    bool hasUpdated = true;

    private void Start()
    {
        discordC = GetComponent<DiscordController>();
    }
    private void Update()
    {
        if (Application.loadedLevel == 2 && !hasUpdated)
        {
            FrPrototype();
        }
        else if (Application.loadedLevel == 1 && !hasUpdated)
        {
            MenuStart();
        }
    }

    public void MenuStart()
    {
        discordC.presence.details = "In Menus";
        DiscordRpc.UpdatePresence(ref discordC.presence);
        print("Discord: Updated For Menus");
        hasUpdated = true;
    }
    public void FrPrototype()
    {
        discordC.presence.details = "In Firing Range";
        discordC.presence.state = "Map: Prototype";
        DiscordRpc.UpdatePresence(ref discordC.presence);
        print("Discord: Updated For FrPrototype");
        hasUpdated = true;
    }

    private void OnLevelWasLoaded(int level)
    {
        hasUpdated = false;
    }
}
