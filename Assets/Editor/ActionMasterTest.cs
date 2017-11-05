using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{


    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp] //this runs every time when test runs
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T1PassingTest()
    {
        Assert.AreEqual(1, 1);
    }


    [Test]
    public void T2FirstStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T3Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T4Bowl28ReturnsEndTurn()
    {
        int[] rolls = { 2, 8 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T5CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T6ChecResetAtSpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T7EndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T8NoBall21AwardedReturnsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));


    }

    [Test]
    public void T9StrikeAnd5ReturnsReset()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void TT10StrikeAnd0ReturnsTidy()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0};    
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void TT11FirstFrame010SecondFrame51ReturnsTidy()
    {
        int[] rolls = { 0, 10, 5 ,1};
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void TT12FirstFrame19ReturnsEndTurn()
    {
        int[] rolls = { 1, 9 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void TT13Dondi10thFrameTurkey()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };       
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void TT13FirstFrame01ReturnsEndTurn()
    {
        int[] rolls = { 0, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
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

