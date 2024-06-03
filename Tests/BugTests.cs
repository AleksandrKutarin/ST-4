//Copyright Kutarin Alexandr

namespace Tests;

[TestClass]
public class BugTests
{
    [TestMethod]
    public void TestMethod1(){
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void CloseAssignTest(){
        var bug = new Bug(Bug.State.Open);
        bug.Assign();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Assigned, state);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void OpenAssignTest(){
        var bug = new Bug(Bug.State.Open);
        bug.Close();
        Bug.State state = bug.getState();
        Assert.AreNotEqual(Bug.State.Closed, state);
        Assert.AreEqual(Bug.State.Open, state);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void DeferAssignTest(){
        var bug = new Bug(Bug.State.Open);
        bug.Defer();
        Bug.State state = bug.getState();
        Assert.AreNotEqual(Bug.State.Defered, state);
        Assert.AreEqual(Bug.State.Open, state);
    }

    [TestMethod]
    public void AssignCloseTest(){
        var bug = new Bug(Bug.State.Closed);
        bug.Assign();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Assigned, state);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void DeferAssignCloseTest(){
        var bug = new Bug(Bug.State.Closed);
        bug.Defer();
        Bug.State state = bug.getState();
        Assert.AreNotEqual(Bug.State.Defered, state);
        Assert.AreEqual(Bug.State.Closed, state);
    }

    [TestMethod]
    public void DeferToAssignedTest(){
        var bug = new Bug(Bug.State.Defered);
        bug.Assign();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Assigned, state);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void DeferToClosedTest(){
        var bug = new Bug(Bug.State.Defered);
        bug.Close();
        Bug.State state = bug.getState();
        Assert.AreNotEqual(Bug.State.Closed, state);
        Assert.AreEqual(Bug.State.Defered, state);
    }

    [TestMethod]
    public void AssignedToDeferTest(){
        var bug = new Bug(Bug.State.Assigned);
        bug.Defer();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Defered, state);
    }

    [TestMethod]
    public void AssignedToClosedTest(){
        var bug = new Bug(Bug.State.Assigned);
        bug.Close();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Closed, state);
    }
    
    [TestMethod]
    public void OpenToFeachedTest(){
        var bug = new Bug(Bug.State.Open);
        bug.Feach();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Feached, state);
    }

    [TestMethod]
    public void AssignedToFeachedTest(){
        var bug = new Bug(Bug.State.Assigned);
        bug.Feach();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Feached, state);
    }

    [TestMethod]
    public void DeferedToFeachedTest(){
        var bug = new Bug(Bug.State.Defered);
        bug.Feach();
        Bug.State state = bug.getState();
        Assert.AreEqual(Bug.State.Feached, state);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void ClosedToFeachedTest(){
        var bug = new Bug(Bug.State.Closed);
        bug.Feach();
        Bug.State state = bug.getState();
        Assert.AreNotEqual(Bug.State.Feached, state);
        Assert.AreEqual(Bug.State.Closed, state);
    }
}
