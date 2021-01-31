namespace Switches
{

    public class Math
    {
        public static int GetResult(int a, int b, int operation)
        {
            switch (operation)
            {
                case 0:
                    return a + b;
                case 1:
                    return a * b;
                case 2:
                    return a / b;
                case 3:
                    return a - b;
                default:
                    return 0;
            }

        }

    }
}
