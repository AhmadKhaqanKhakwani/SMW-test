using SMW_test.Services.Interface;
using SMW_test.Utilities.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMW_test.Services.Implementation
{
    public class NumberService : INumberService
    {
        private SortedSet<int> sortedSet = new SortedSet<int>();
        private LinkedList<int> linkedList = new LinkedList<int>();
        private BinarySearchTree binarySearchTree = new BinarySearchTree();

        private string activeDataStructure = "SortedSet";

        public async Task AddNumberAsync(int number)
        {
            await Task.Run(() => {
                sortedSet.Add(number);
                linkedList.AddLast(number);
                binarySearchTree.Add(number);
            });
        }

        public async Task<int?> GetMaxAsync()
        {
            return await Task.Run(() => {
                switch (activeDataStructure)
                {
                    case "SortedSet":
                        return sortedSet.Max;
                    case "LinkedList":
                        return linkedList.Max();
                    case "BTree":
                        return binarySearchTree.GetMax();
                    default:
                        throw new InvalidOperationException("Unknown data structure.");
                }
            });
        }

        public async Task<int?> GetMinAsync()
    {
        return await Task.Run(() => {
            switch (activeDataStructure)
            {
                case "SortedSet":
                    return sortedSet.Min;
                case "LinkedList":
                    return linkedList.Min();
                case "BTree":
                    return binarySearchTree.GetMin();
                default:
                    throw new InvalidOperationException("Unknown data structure.");
            }
        });
    }

    public void SetActiveDataStructure(string dataStructure)
    {
        activeDataStructure = dataStructure;
    }
}


}
