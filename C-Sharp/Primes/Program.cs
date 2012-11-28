/**
 * @file   Program.cs
 * @Author Frank Swehosky (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Enumerate a range of primes
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 * 
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Primes
{
    public class Primes
    {
        private long m_min;
        private long m_max;
        //Default constructor has the default min == 2 and max = 100
        public Primes(): this(2, 100)
        {

        }
        public Primes(long minimum, long maximum)
        {
            if (m_min < 2)
                m_min = 2;
            else
                m_min = minimum;
            m_max = maximum;
            if (m_max < m_min)
                m_max = m_min + 1;
        }
        public IEnumerator GetEnumerator()
        {
            //Check each potential prime in the range
            for (long possible = m_min; possible <= m_max; possible++)
            {
                bool isPrime = true;
                //Check each potential factor of the potential prime
                for (long factor = 2; factor <= (long)Math.Floor(Math.Sqrt(possible)); factor++)
                {
                    //If the factor divided evenly into it, it's not prime
                    if (0 == (possible % factor))
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return possible;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Primes primes = new Primes(2, 1000);
            foreach (long i in primes)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();
        }
    }
}
