using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities. Verify that Enqueue places 
    //           each item at the back of the queue. Confirm that Dequeue removes the item with the 
    //           highest priority and returns its value correctly.
    // Expected Result: The item with the highest priority should be dequeued first, followed by the 
    //                 next highest, in descending order
    // Defect(s) Found: The dequeue method skipped the last item and did not remove dequeued items from 
    //                   the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("LastLow", 2);

        string highest = priorityQueue.Dequeue();
        Assert.AreEqual("High", highest); // High priority item should come out first

        // Remaining items should now be dequeued by priority, then FIFO order
        Assert.AreEqual("Medium", priorityQueue.Dequeue());   // Priority 5
        Assert.AreEqual("LastLow", priorityQueue.Dequeue());  // Priority 2
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue several items with equal highest priority. Ensure that the Dequeue method removes
    //  the first one added among them (FIFO) and returns its value.
    // Expected Result: "FirstMax" (priority 10) is dequeued first, followed by "SecondMax" and "ThirdMax"
    //  in the order they were enqueued
    // Defect(s) Found: Thirdmax was dequeued first even though FirstMax was closest to the front of the queue
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstMax", 10);
        priorityQueue.Enqueue("SecondMax", 10);
        priorityQueue.Enqueue("ThirdMax", 10);
        priorityQueue.Enqueue("Low", 2);

        Assert.AreEqual("FirstMax", priorityQueue.Dequeue());  // Checks that the highest priority value closest to the front is dequeued first
        Assert.AreEqual("SecondMax", priorityQueue.Dequeue());
        Assert.AreEqual("ThirdMax", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty PriorityQueue.
    // Expected Result: An InvalidOperationException is thrown to indicate that the queue is empty.
    // Defect(s) Found: none   
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        // Try to remove an item from an empty queue
        priorityQueue.Dequeue();
    }
}

