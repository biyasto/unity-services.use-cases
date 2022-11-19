using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// A utility class for various Addressables functionality
/// </summary>
public static class Addressables_Utility
{
    /// <summary>
    /// Get the address of a given AssetReference.
    /// </summary>
    /// <param name="reference">The AssetReference you want to find the address of.</param>
    /// <returns>The address of a given AssetReference.</returns>
    public static async Task<string> GetAddressFromAssetReference(AssetReference reference)
    {
        var loadResourceLocations = Addressables.LoadResourceLocationsAsync(reference);
        await loadResourceLocations.Task;
        Addressables.Release(loadResourceLocations);
        
        if (loadResourceLocations.Status != AsyncOperationStatus.Succeeded)
            throw new Exception("Task failed to complete!");
        var result = loadResourceLocations.Result;
        Addressables.Release(loadResourceLocations);
        return string.Empty;
    }
}
