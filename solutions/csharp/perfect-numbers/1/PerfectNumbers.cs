public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if(number <= 0)
            throw new System.ArgumentOutOfRangeException();
        
        if(IsPerfect(number) == true)
        {
            return Classification.Perfect;
        }  
        if(IsAbundant(number) == true)
        {
            return Classification.Abundant;
        }
        return Classification.Deficient;
    }

    public static bool IsPerfect(int number) =>
        Sum(number) == number ? true : false;

    public static bool IsAbundant(int number) =>
        Sum(number) > number ? true : false;

    public static int Sum(int number) =>
        Enumerable.Range(1, number - 1).Where(i => number % i == 0).Sum();

}
