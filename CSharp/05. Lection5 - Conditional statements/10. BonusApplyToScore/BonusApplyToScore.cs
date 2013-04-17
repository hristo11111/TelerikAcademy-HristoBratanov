using System;

class BonusApplyToScore
{
    static void Main()
    {
        long score = 56466545L;
        Console.WriteLine("please enter a digit between 1 and 9 : ");
        string digit = Console.ReadLine();
        switch (digit)
        {
            case "1" : 
            case "2" :
            case "3" :
                Console.WriteLine("the score {0} multiplies by 10 = {1}", score, score * 10);
                break;
            case "4" :
            case "5" :
            case "6" :
                Console.WriteLine("the score {0} multiplies by 100 = {1}",score, score * 100);
                break;
            case "7" :
            case "8" :
            case "9" :
                Console.WriteLine("the score {0} multiplies by 1000 = {1}", score, score * 1000);
                break;
            default : Console.WriteLine("ERROR");
                break;
        }
    }
}
