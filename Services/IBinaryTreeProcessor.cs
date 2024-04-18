using BinaryTreeService.Model;

namespace BinaryTreeService.Services;

public interface IBinaryTreeProcessor
{
    BinaryTree? Mirror(BinaryTree? tree);
}
