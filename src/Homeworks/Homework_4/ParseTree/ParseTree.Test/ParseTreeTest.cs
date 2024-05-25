namespace ParseTree.Test;

using ParseTree;

public class Tests
{
    private PTree tree;

    [SetUp]
    public void Setup()
    {
        tree = new PTree();
    }

    [TestCase(67, "(- * / (+ 138 2)10 5 3)")]
    [TestCase(4, "(* (+ 1 1) 2)")]
    [TestCase(0, "(/ (- 1 1) 5)")]
    [TestCase(6.4F, "/ (+ 25 7)(- 9 4)")]
    public void BuildAndCalculate_WithCorrectInput_WorksCorrectly(float expected, string expression)
    {
        tree.BuildTree(expression);

        Assert.AreEqual(expected, tree.Calculate());
    }

    [TestCase("(- * / (+ 138 2)10 5 3)", "- * / + 138 2 10 5 3")]
    [TestCase("(* (+ 1 1) 2)", "* + 1 1 2")]
    [TestCase("(/ (- 1 1) 5)", "/ - 1 1 5")]
    [TestCase("/ (+ 25 7)(- 9 4)", "/ + 25 7 - 9 4")]
    public void GetTree_WorksCorrectly_WithCorrectInput(string inputString, string expected)
    {
        tree.BuildTree(inputString);
        var result = tree.GetTree();
       
        Assert.AreEqual(expected, result);
    }

    [TestCase("3 * 3")]
    [TestCase("(* / (+ 138 2)10 5 ) - 3)")]
    public void BuildTree_WithIncorrectInput_ThrowArgumentException(string expression)
    {
        Assert.Throws<ArgumentException>(() => tree.BuildTree(expression));
    }

    [TestCase("/ 5 0")]
    public void Calculate_WithDivideByZero_ThrowException(string expression)
    {
        tree.BuildTree(expression);

        Assert.Throws<ArgumentException>(() => tree.Calculate());
    }

    [Test]
    public void GetTree_WithEmptyTree_ThrowException()
    {
        tree.BuildTree("");
        Assert.Throws<ArgumentNullException>(() => tree.GetTree());
    }

    [Test]
    public void Calculate_WithEmptyTree_ThrowException()
    {
        tree.BuildTree("");
        Assert.Throws<ArgumentNullException>(() => tree.Calculate());
    }

    [TestCase("(* 3 A)")]
    [TestCase("(% 3 3)")]
    public void Build_WithUnknownSymbols_ThrowException(string expression)
    {
        Assert.Throws<ArgumentException>(() => tree.BuildTree(expression));
    }
}