using BinaryTreeService.Exceptions;
using BinaryTreeService.Model;

namespace BinaryTreeService.Services;

public class BinaryTreeProcessor : IBinaryTreeProcessor
{
    public BinaryTreeProcessor()
    {
    }

    public BinaryTree? Mirror(BinaryTree? tree)
    {
        if (tree == null || !tree.IsValid())
        {
            return null;
        }

        BinaryTree? left = Mirror(tree.Left);
        BinaryTree? right = Mirror(tree.Right);

        tree.Left = right;
        tree.Right = left;

        return tree;
    }

}