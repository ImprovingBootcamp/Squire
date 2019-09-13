---
layout: default
title: Numbers Kihon
---
```cs
protected override int Return_The_Maximum_Value_Of_Int32()
{
    return int.MaxValue;
}

protected override int Return_The_Minimum_Value_Of_Int32()
{
    return int.MinValue;
}

protected override int Return_The_Remainder_Of_a_Divided_By_b(int a, int b)
{
    return a % b;
}

protected override double Return_The_Maximum_Value_Of_Double()
{
    return double.MaxValue;
}

protected override double Return_The_Minimum_Value_Of_Double()
{
    return double.MinValue;
}

protected override bool Return_True_If_a_Is_Not_A_Number(double a)
{
    return double.IsNaN(a);
}

protected override bool Return_True_If_a_Is_An_Infinity(double a)
{
    return double.IsInfinity(a);
}
```
