using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEditor;
using System.Collections;

public class ProceduralGenerationTest {


	[UnityTest]
	public IEnumerator ProceduralGenerationTestWithEnumeratorPasses() {

        var prefab1 = Resources.Load("Prefabs/Procedural/BlockBig");
        var prefab2 = Resources.Load("Prefabs/Procedural/BlockMedium");
        var prefab3 = Resources.Load("Prefabs/Procedural/BlockSmall");
        var prefab4 = Resources.Load("Prefabs/Procedural/EmptyBlock");

        yield return null;

        var spawnedBlocks = GameObject.FindWithTag("blockPrefab");
        var spawnedPrefab = PrefabUtility.GetPrefabParent(spawnedBlocks);
        Assert.IsTrue(spawnedPrefab == prefab1 || spawnedPrefab == prefab2 || spawnedPrefab == prefab3 || spawnedPrefab == prefab4);
	}

    [TearDown]
    public void CleanTest()
    {
        foreach (var GameObject in GameObject.FindGameObjectsWithTag("blockPrefab"))
            Object.Destroy(GameObject);
    }
}
