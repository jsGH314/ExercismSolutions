public static class SquareRoot
{
    public static int Root(int number)
    {
        int root = 1;
        for(int i = 0; i < number; i++)
        {
            if(i*i == number)
            {
                root = i;
            }
        }
        return root;
    }
}
