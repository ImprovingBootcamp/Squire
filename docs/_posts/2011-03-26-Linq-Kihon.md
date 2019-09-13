---
layout: default
title: Linq Kihon
---
```cs
protected override IEnumerable<int> Select_the_Something_property_from_list(List<Product> list)
{
    return list.Select(x => x.Something);
}

protected override IEnumerable<Product> Order_the_list_by_the_something_property_descending(List<Product> list)
{
    return list.OrderByDescending(x => x.Something);
}

protected override IEnumerable<Product> Order_the_list_by_the_something_property(List<Product> list)
{
    return list.OrderBy(x => x.Something);
}

protected override IEnumerable<Product> Filter_the_products_where_something_is_equal_to_2_from_list(List<Product> list)
{
    return list.Where(x => x.Something == 2);
}
```
