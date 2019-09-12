---
layout: default
title: Linq Kihon
---
```
         protected override IEnumerable&lt;int&gt; Select_the_Something_property_from_list(List&lt;Product&gt; list)
        {
            return list.Select(x =&gt; x.Something);
        }

        protected override IEnumerable&lt;Product&gt; Order_the_list_by_the_something_property_descending(List&lt;Product&gt; list)
        {
            return list.OrderByDescending(x =&gt; x.Something);
        }

        protected override IEnumerable&lt;Product&gt; Order_the_list_by_the_something_property(List&lt;Product&gt; list)
        {
            return list.OrderBy(x =&gt; x.Something);
        }

        protected override IEnumerable&lt;Product&gt; Filter_the_products_where_something_is_equal_to_2_from_list(List&lt;Product&gt; list)
        {
            return list.Where(x =&gt; x.Something == 2);
        }
```
