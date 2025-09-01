public static class CollatzConjecture
{

    /*public static int Steps(int number, int steps = 0) => 
        number == 1 ? steps : Steps(number % 2 == 0 ? number / 2 : 3 * number + 1, steps + 1);*/

  
    public static int Steps(int number)
    {
        if (number < 1)
        {
            throw new ArgumentOutOfRangeException("Number must be a positive integer.");
        }
        
        int steps = 0;
        long currentNum = number;
        while(currentNum != 1)
        {
            
            if(currentNum % 2 == 0)
                currentNum /= 2;
            else
                currentNum = (currentNum*3) + 1;
            steps++;
        }
        return steps;
    }
}