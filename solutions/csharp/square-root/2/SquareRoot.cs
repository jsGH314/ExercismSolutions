public static class SquareRoot
{
    public static int Root(int number)
    {
        int root = 1;

        while(root*root != number)
        {
            root++;
        }

        return root;
    }
}
