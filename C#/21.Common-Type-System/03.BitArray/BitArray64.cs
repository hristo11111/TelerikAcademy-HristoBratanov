using System;
using System.Collections;
using System.Collections.Generic;

class BitArray64 : IEnumerable<int>
{
    private ulong number;
    public ulong Number
    {
        get
        {
            return this.number;
        }
        set
        {
            if (number > 18446744073709551615 || number < 0)
            {
                throw new IndexOutOfRangeException("the input is not in ulong range");
            }
            this.number = value;
        }
    }

    public BitArray64(ulong number)
    {
        this.Number = number;
    }

    //public IEnumerator<UInt64> GetEnumerator()
    //{
    //    BitArray64<UInt64> currentNum = this;
    //    while (currentNum != null)
    //    {
    //        yield return currentNum;
            
    //    }
    //}


    public IEnumerator<int> GetEnumerator()
    {
        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
