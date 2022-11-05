namespace Task_2.Services;

public class SolutionService
{
    public static int GetProblemAnswer(int n, int k)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            int cur = i;

            while (cur > 0)
            {
                int lastDigit = cur % 10;

                if (lastDigit == k)
                    count++;

                cur /= 10;
            }
        }

        return count;
    }
}
