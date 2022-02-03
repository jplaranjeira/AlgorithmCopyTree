

using AlgorithmCopyTree.Entities;
using AlgorithmCopyTree.Utils;

public class Program
{
    static void Main()
    {
        PrintTreeBranchWithBreadthFirstSearch();
        //PrintTreeBranchWithDepthFirstSearch();
    }

    private static void PrintTreeBranchWithBreadthFirstSearch() 
    {
        TreeBranch treeBranch1 = CreateContent();

        if (treeBranch1 != null)
        {
            BreadthFirstSearch.PrintTreeBranch(treeBranch1.Childs);
            Console.WriteLine("\n");
            BreadthFirstSearch.PrintTreeBranch(BreadthFirstSearch.CopyTreeBranch(treeBranch1, null));
        }
    }

    private static void PrintTreeBranchWithDepthFirstSearch() 
    {
        TreeBranch treeBranch1 = CreateContent();

        if (treeBranch1 != null)
        {
            DepthFirstSearch.PrintTreeBranch(treeBranch1.Childs);
            Console.WriteLine("\n");
            DepthFirstSearch.PrintTreeBranch(DepthFirstSearch.CopyTreeBranch(treeBranch1.Childs, null, null));
        }
    }

    private static TreeBranch CreateContent()
    {
        TreeBranch treeBranch1 = new TreeBranch(1, "Nível 1");
        
        TreeBranch treeBranch11 = new TreeBranch(11, " Nível 11");
        TreeBranch treeBranch12 = new TreeBranch(12, " Nível 12");
        TreeBranch treeBranch13 = new TreeBranch(13, " Nível 13");

        TreeBranch treeBranch121 = new TreeBranch(121, "  Nível 121");
        TreeBranch treeBranch122 = new TreeBranch(122, "  Nível 122");
        TreeBranch treeBranch131 = new TreeBranch(131, "  Nível 131");
        TreeBranch treeBranch132 = new TreeBranch(132, "  Nível 132");
        TreeBranch treeBranch133 = new TreeBranch(133, "  Nível 133");

        TreeBranch treeBranch1321 = new TreeBranch(1321, "   Nível 1321");
        TreeBranch treeBranch1322 = new TreeBranch(1321, "   Nível 1322");

        TreeBranch treeBranch13211 = new TreeBranch(13211, "    Nível 13211");
        TreeBranch treeBranch13212 = new TreeBranch(13212, "    Nível 13212");


        treeBranch12.Childs.Add(treeBranch121);
        treeBranch12.Childs.Add(treeBranch122);
        treeBranch1321.Childs.Add(treeBranch13211);
        treeBranch1321.Childs.Add(treeBranch13212);
        treeBranch132.Childs.Add(treeBranch1321);
        treeBranch132.Childs.Add(treeBranch1322);
        treeBranch13.Childs.Add(treeBranch131);
        treeBranch13.Childs.Add(treeBranch132);
        treeBranch13.Childs.Add(treeBranch133);
        treeBranch1.Childs.Add(treeBranch11);
        treeBranch1.Childs.Add(treeBranch12);
        treeBranch1.Childs.Add(treeBranch13);

        return treeBranch1;
    }
}
