using AlgorithmCopyTree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCopyTree.Utils
{
    public static class DepthFirstSearch
    {
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

        private static TreeBranch CopyTreeBranchContent(TreeBranch oldTreeBranch)
        {
            return new TreeBranch(oldTreeBranch.Id, oldTreeBranch.Name + " (New)");;
        }
    }
}
