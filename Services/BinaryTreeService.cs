public class BinaryTreeService : IBinaryTreeService
{
    public BinaryTreeService()
    {
    }

    public BinaryTree Mirror(BinaryTree tree)
    {
        if (tree == null)
        {
            return null;
        }

        BinaryTree left = Mirror(tree.Left);
        BinaryTree right = Mirror(tree.Right);

        tree.Left = right;
        tree.Right = left;

        return tree;
    }

}