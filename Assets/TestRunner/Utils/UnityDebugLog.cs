using Unity.Collections;
using UnityEngine;

namespace TestRunner.Utils
{
    internal static class UnityDebugLog
    {
        internal static void DisposeStructWarningLog(string itemName, string message)
        {
            Debug.LogWarning(
                "Try don't Dispose manually data of job." +
                $" Also don't use attribute {nameof(DeallocateOnJobCompletionAttribute)} on struct {itemName}." +
                "\nLet the system automatically dispose data." +
                $"\n{message}"
            );
        }
    }
}