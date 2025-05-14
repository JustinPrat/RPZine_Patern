using Reflex.Core;
using UnityEngine;
using UnityEngine.Rendering;

public class SceneInstaller : MonoBehaviour, IInstaller
{
    public void InstallBindings(ContainerBuilder builder)
    {
        if (!TryGetComponent(out Updater updater))
        {
            updater = gameObject.AddComponent<Updater>();
        }

        builder.AddSingleton(updater);
    }
}