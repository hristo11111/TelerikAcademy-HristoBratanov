using System;
using System.Text;

static class SubstringForStringBuilder
{
    public static StringBuilder Substring(this StringBuilder sb, int index)
    {
        if (index > sb.Length - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException("index must be non-negatve and index must be < length of the StringBuilder");
        }
        else
        {
            StringBuilder sum = new StringBuilder();
            for (int i = index; i < sb.Length; i++)
            {
                sum.Append(sb[i]);
            }
            return sum;
        }
    }

    public static StringBuilder Substring(this StringBuilder sb, int index, int length)
    {
        if (index > sb.Length - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException("index must be non-negatve and index must be < length of the StringBuilder");
        }
        else if (length > sb.Length - index)
	    {
            throw new ArgumentOutOfRangeException("length must be < (sb.length-index)");
	    }
        else if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length must be non-negative");
        }
        else
        {
            StringBuilder sum = new StringBuilder();
            for (int i = index; i < index + length; i++)
            {
                sum.Append(sb[i]);
            }
            return sum;
        }
        
    }

}
