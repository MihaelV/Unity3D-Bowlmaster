using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ActionMasterTest{

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;


    [Test]
    public void T1PassingTest()
    {
        Assert.AreEqual(1, 1);
    }


    [Test]
    public void T2FirstStrikeReturnsEndTurn()
    {
        ActionMaster actionMaster = new ActionMaster();
        Assert.AreEqual(endTurn,actionMaster.Bowl(10));
    }
    



	//[Test]
	//public void ScoreMasterTestSimplePasses() {
	//	// Use the Assert class to test conditions.
	//}

	//// A UnityTest behaves like a coroutine in PlayMode
	//// and allows you to yield null to skip a frame in EditMode
	//[UnityTest]
	//public IEnumerator ScoreMasterTestWithEnumeratorPasses() {
	//	// Use the Assert class to test conditions.
	//	// yield to skip a frame
	//	yield return null;
	//}
}
