﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Squire.Framework;

namespace Squire
{
    [TestFixture]
    public class StringKihon : StringKihonBase
    {
        protected override string Convert_To_Uppercase(string data)
        {
        	return data.ToUpper();
        }

        protected override string Convert_To_Lowercase(string data)
        {
        	return data.ToLower();
        }

        protected override string Combine_Parts_Of_A_Name(string firstName, string middleName, string lastName)
        {
            return firstName + " " + middleName + " " + lastName;
        }

        protected override string Combine_Two_Strings(string a, string b)
        {
            return a + b;
        }

        protected override int Determine_The_Length_Of_A_String(string data)
        {
            return data.Length;
        }

        protected override string Remove_All_Leading_Whitespace(string data)
        {
        	return data.TrimStart();
        }

        protected override string Remove_All_Trailing_Whitespace(string data)
        {
        	return data.TrimEnd();
        }

        protected override string[] Split_A_String_Into_An_Array(string input, char divider)
        {
        	return input.Split(divider);
        }

        protected override string Join_An_Array_Into_A_String(string[] input, string divider)
        {
        	return string.Join(divider, input);
        }

        protected override bool Return_True_If_a_Contains_b(string a, string b)
        {
        	return a.Contains(b);
        }

        protected override int Determine_The_Position_Of_a_In_b(string a, string b)
        {
        	return b.IndexOf(a);
        }

        protected override bool Return_True_If_a_Starts_With_b(string a, string b)
        {
        	return a.StartsWith(b);
        }

        protected override bool Return_True_Is_a_Ends_With_b(string a, string b)
        {
        	return a.EndsWith(b);
        }

        protected override string Return_The_Fourth_Through_Seventh_Characters_Of_Input(string input)
        {
        	return input.Substring(3,4);
        }
    }
}
