using System.ComponentModel.DataAnnotations;

namespace BinaryTreeService.Model;

public class BinaryTree
{
    [Required]
    public string Name { get; set; }
    public BinaryTree? Left { get; set; }
    public BinaryTree? Right { get; set; }

    public bool IsValid()
    {
        if (Name == null)
        {
            return false;
        }

        return true;
    }
}
