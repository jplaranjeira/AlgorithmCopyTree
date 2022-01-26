public class TreeBranch
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<TreeBranch>? Childs { get; set; }
}

public class Program
{
    static void Main()
    {
        TreeBranch treeBranch1 = new TreeBranch();
        treeBranch1.Id = 1;
        treeBranch1.Name = "Nível 1";
        treeBranch1.Childs = new List<TreeBranch>();

        TreeBranch treeBranch11 = new TreeBranch();
        treeBranch11.Id = 11;
        treeBranch11.Name = " Nível 11";
        treeBranch11.Childs = new List<TreeBranch>();

        TreeBranch treeBranch12 = new TreeBranch();
        treeBranch12.Id = 12;
        treeBranch12.Name = " Nível 12";
        treeBranch12.Childs = new List<TreeBranch>();

        TreeBranch treeBranch13 = new TreeBranch();
        treeBranch13.Id = 13;
        treeBranch13.Name = " Nível 13";
        treeBranch13.Childs = new List<TreeBranch>();

        TreeBranch treeBranch121 = new TreeBranch();
        treeBranch121.Id = 121;
        treeBranch121.Name = "  Nível 121";
        treeBranch121.Childs = new List<TreeBranch>();

        TreeBranch treeBranch122 = new TreeBranch();
        treeBranch122.Id = 122;
        treeBranch122.Name = "  Nível 122";
        treeBranch122.Childs = new List<TreeBranch>();

        TreeBranch treeBranch131 = new TreeBranch();
        treeBranch131.Id = 131;
        treeBranch131.Name = "  Nível 131";
        treeBranch131.Childs = new List<TreeBranch>();

        TreeBranch treeBranch132 = new TreeBranch();
        treeBranch132.Id = 132;
        treeBranch132.Name = "  Nível 132";
        treeBranch132.Childs = new List<TreeBranch>();

        TreeBranch treeBranch1321 = new TreeBranch();
        treeBranch1321.Id = 1321;
        treeBranch1321.Name = "   Nível 1321";
        treeBranch1321.Childs = new List<TreeBranch>();

        TreeBranch treeBranch133 = new TreeBranch();
        treeBranch133.Id = 133;
        treeBranch133.Name = "  Nível 133";
        treeBranch133.Childs = new List<TreeBranch>();


        treeBranch12.Childs.Add(treeBranch121);
        treeBranch12.Childs.Add(treeBranch122);

        treeBranch132.Childs.Add(treeBranch1321);

        treeBranch13.Childs.Add(treeBranch131);
        treeBranch13.Childs.Add(treeBranch132);
        treeBranch13.Childs.Add(treeBranch133);

        treeBranch1.Childs.Add(treeBranch12);
        treeBranch1.Childs.Add(treeBranch13);


        PrintTreeBranch(treeBranch1.Childs);
        Console.WriteLine("\n");
        PrintTreeBranch(CopyTreeBranch(treeBranch1.Childs, null, null));

    }

    public static void PrintTreeBranch(List<TreeBranch> treeBranchList)
    {
        foreach (TreeBranch treeBranch in treeBranchList)
        {
            if (treeBranch.Childs != null && treeBranch.Childs.Count() > 0)
            {
                Console.WriteLine(treeBranch.Name);
                PrintTreeBranch(treeBranch.Childs);
            }
            else Console.WriteLine(treeBranch.Name);
        }
    }

    public static List<TreeBranch> CopyTreeBranch(List<TreeBranch> oldTreeBranchList, List<TreeBranch>? newTreeBranchList, TreeBranch? parentTreeBranch)
    {
        newTreeBranchList = newTreeBranchList == null ? new List<TreeBranch>() : newTreeBranchList;

        foreach (TreeBranch treeBranch in oldTreeBranchList)
        {
            if (treeBranch.Childs != null && treeBranch.Childs.Count() > 0)
            {
                if (parentTreeBranch != null)
                {
                    TreeBranch? currentTreeBranch = newTreeBranchList != null ? newTreeBranchList.Where(t => t.Id == parentTreeBranch.Id).FirstOrDefault() : null;
                    currentTreeBranch?.Childs?.Add(CopyTreeBranchContent(treeBranch));
                }
                else newTreeBranchList?.Add(CopyTreeBranchContent(treeBranch));


                CopyTreeBranch(treeBranch.Childs, newTreeBranchList, treeBranch);
            }
            else
            {
                newTreeBranchList?.Add(CopyTreeBranchContent(treeBranch));
            }
        }

        return newTreeBranchList;
    }

    public static TreeBranch CopyTreeBranchContent(TreeBranch oldTreeBranch)
    {
        return new TreeBranch
        {
            Id = oldTreeBranch.Id,
            Name = oldTreeBranch.Name + " (New)",
            Childs = new List<TreeBranch>()
        };
    }
}
