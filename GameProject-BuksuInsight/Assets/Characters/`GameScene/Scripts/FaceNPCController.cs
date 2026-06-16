using UnityEngine;

public class FaceNPCController : MonoBehaviour
{
    public Transform player;
    public Transform npc;

    public void MakeThemLookAtEachOther()
    {
        if (player == null || npc == null) return;

        // PLAYER looks at NPC
        Vector3 playerDir = npc.position - player.position;
        playerDir.y = 0; // keep rotation only on the Y axis
        player.rotation = Quaternion.LookRotation(playerDir);

        // NPC looks at PLAYER
        Vector3 npcDir = player.position - npc.position;
        npcDir.y = 0;
        npc.rotation = Quaternion.LookRotation(npcDir);
    }
}
