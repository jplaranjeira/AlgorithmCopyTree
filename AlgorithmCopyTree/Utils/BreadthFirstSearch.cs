using AlgorithmCopyTree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCopyTree.Utils
{
    public static class BreadthFirstSearch
    {
        public static List<TreeBranch> CopyTreeBranch(TreeBranch oldTreeBranch, List<TreeBranch>? newTreeBranchList)
        {
            newTreeBranchList = newTreeBranchList == null ? new List<TreeBranch> { CopyTreeBranchContent(oldTreeBranch, "") } : newTreeBranchList;
            
            //not analyzed branches
            TreeBranch tempTreeBranches = new TreeBranch();
            TreeBranch parentTree;

            if (oldTreeBranch != null && oldTreeBranch.Childs != null)
            {

                foreach (TreeBranch treeBranch in oldTreeBranch.Childs)
                {
                    if (oldTreeBranch != null && oldTreeBranch.Id != 0)
                    {
                        newTreeBranchList[0].Childs?.Add(CopyTreeBranchContent(treeBranch, oldTreeBranch.Id.ToString()));
                    }

                    if (treeBranch.Childs != null && treeBranch.Childs.Count() > 0)
                    {
                        foreach (TreeBranch childTreeBranch in treeBranch.Childs)
                        {
                            parentTree = null;
                            GetTreeBranchById(newTreeBranchList, treeBranch.Id, out parentTree);

                            if (parentTree != null)
                            {
                                //First Level + N
                                if (parentTree.Childs != null)
                                {
                                    parentTree.Childs.Add(CopyTreeBranchContent(childTreeBranch, treeBranch.Id.ToString()));
                                }
                                else
                                {
                                    parentTree.Childs = new List<TreeBranch> { CopyTreeBranchContent(childTreeBranch, treeBranch.Id.ToString()) };
                                }
                            }
                            else
                            {
                                //First Level
                                newTreeBranchList.Add(CopyTreeBranchContent(childTreeBranch, treeBranch.Id.ToString()));
                            }
                            //add to next level list
                            tempTreeBranches.Childs.Add(childTreeBranch);
                        }
                    }
                }

            }           

            if(tempTreeBranches != null && tempTreeBranches.Childs.Count() > 0) 
            {
                CopyTreeBranch(tempTreeBranches, newTreeBranchList);
            }            

            return newTreeBranchList;
        }


        public static void PrintTreeBranch(List<TreeBranch> treeBranchList)
        {
            //not analyzed branches
            List<TreeBranch> tempTreeBranches = new List<TreeBranch>();

            foreach (TreeBranch treeBranch in treeBranchList)
            {
                if (treeBranch.Childs != null && treeBranch.Childs.Count() > 0)
                {
                    foreach (TreeBranch childTreeBranch in treeBranch.Childs) 
                    {
                        tempTreeBranches.Add(childTreeBranch);
                    }
                    
                }
                
                Console.WriteLine(treeBranch.Name);
            }

            if(tempTreeBranches.Count > 0) 
            {
                PrintTreeBranch(tempTreeBranches);
            }   
        }

        public static void GetTreeBranchById(List<TreeBranch> treeBranchList, int id, out TreeBranch selectedTreeBranch)
        {
            List<TreeBranch> tempTreeBranches = new List<TreeBranch>();
            selectedTreeBranch = null;
            bool founded = false;

            foreach (TreeBranch treeBranch in treeBranchList)
            {
                if(treeBranch.Id == id) 
                {
                    selectedTreeBranch = treeBranch;
                    founded = true;
                    break;
                }

                if (treeBranch.Childs != null && treeBranch.Childs.Count() > 0)
                {
                    foreach (TreeBranch childTreeBranch in treeBranch.Childs)
                    {
                        if(childTreeBranch.Id == id) 
                        {
                            selectedTreeBranch = childTreeBranch;
                            founded = true;
                            break;
                        }

                        tempTreeBranches.Add(childTreeBranch);
                    }

                }
            }

            if (tempTreeBranches.Count > 0 && !founded)
            {
                GetTreeBranchById(tempTreeBranches, id, out selectedTreeBranch);
            }
        }

        private static TreeBranch CopyTreeBranchContent(TreeBranch oldTreeBranch, string parentId)
        {
            string parentReview = string.IsNullOrEmpty(parentId) ? "" : (" : " + "child of " + parentId);
            return new TreeBranch(oldTreeBranch.Id, oldTreeBranch.Name + " (New)" + parentReview);
        }
    }
}
