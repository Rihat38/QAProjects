namespace Exam.Framework;

public static class Utils
{
    public static bool CompareTwoByteArrays(byte[] arr1, byte[] arr2)
    {
        var comparer = true;
        if (arr1.Length.Equals(arr2.Length))
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                comparer = arr1[i] == arr2[i];
                if (comparer == false)
                    break;
            }
        }
        else 
            comparer = false;
        
        return comparer;
    }
    
    public static bool IsDateValuesInDescendingOrder(List<DateTime> list)
    {
        var previousDate = list.First();
        
        foreach (var v in list)
        {
            if (previousDate < v)
            {
                return false;
            }
            previousDate = v;
        }

        return true;
    }
}