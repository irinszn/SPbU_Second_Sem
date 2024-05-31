namespace Routers.Test;

public class Tests
{
    [TestCase("../../../TestFiles/CorrectInput_1.txt", "../../../TestFiles/ExpectedOutput_1.txt")]
    [TestCase("../../../TestFiles/CorrectInput_2.txt", "../../../TestFiles/ExpectedOutput_2.txt")]
    public void BuildOptimalTopology_WithCorrectInput_WorksCorrectly(string inputFile, string expectedFile)
    {
        var topology = File.ReadAllText(inputFile);
        string optimalTopology = MakeTopology.BuildOptimalTopology(topology);
        var expectedTopology = File.ReadAllText(expectedFile);

        Assert.That(optimalTopology, Is.EqualTo(expectedTopology));
    }

    [TestCase("1 : 2(10)")]
    [TestCase("# : 2 (10)")]
    [TestCase("1 : 2 (10). d (8)")]
    [TestCase(" : 2 (10)")]
    [TestCase("1 : ")]
    [TestCase("some string")]
    public void BuildOptimalTopology_WithIncorrectInput_ThrowsExeptions(string inputString)
    {
        Assert.Throws<ArgumentException>(() => MakeTopology.BuildOptimalTopology(inputString));
    }

    [TestCase("../../../TestFiles/DisconnectedGraph.txt")]
    public void BuildOptimalTopology_WithDisconnectedGraph_ThrowsDisconnectedGraphExeption(string file)
    {
        Assert.Throws<DisconnectedGraphException>(() => MakeTopology.BuildOptimalTopology(File.ReadAllText(file)));
    }

    [Test]
    public void BuildOptimalTopology_WithEmptysString_ThrowsExeption()
    {
        Assert.Throws<ArgumentException>(() => MakeTopology.BuildOptimalTopology(""));
    }

    [Test]
    public void BuildOptimalTopology_WithNegativeWeight_ThrowsExeption()
    {
        Assert.Throws<ArgumentException>(() => MakeTopology.BuildOptimalTopology("1 : 2 (-1)"));
    }
}