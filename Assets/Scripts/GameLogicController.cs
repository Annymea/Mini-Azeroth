using Unity.VectorGraphics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicController : MonoBehaviour
{
    public enum Scenes
    {
        restart,
        openWorld
    }

    public void SwitchToRestartScene()
    {
        SwitchToScene(Scenes.restart);
    }

    public void SwitchToOpenWorld()
    {
        SwitchToScene(Scenes.openWorld);
    }

    public void SwitchToScene(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.restart:
                SceneManager.LoadScene("Assets/Scenes/RestartScene.unity");
                break;
            case Scenes.openWorld:
                SceneManager.LoadScene("Assets/Scenes/OpenWorld.unity");
                break;

        }
    }

}
