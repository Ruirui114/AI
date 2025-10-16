using UnityEngine;

public class Jump : MonoBehaviour
{
    public Player player; // Player�X�N���v�g��Inspector�œo�^
    public KeyCode toggleKey = KeyCode.LeftShift;

    private bool jumpEnabled = true;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            jumpEnabled = !jumpEnabled;
            player.canJump = jumpEnabled;
        }
    }
}
