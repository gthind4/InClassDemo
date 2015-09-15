<Query Kind="Expression">
  <Connection>
    <ID>fc3922b5-2878-489c-bf3c-5d3707f013f5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//order by
//default ascending
from food in Items
orderby food.Description
select food

//in descending order
from food in Items
orderby food.CurrentPrice descending
select food

//both ascending and descending
from food in Items
orderby food.CurrentPrice descending, food.Calories ascending
select food

//both ascending and descending
from food in Items
where food.MenuCategory.Description.Equals("Entree")
orderby food.CurrentPrice descending, food.Calories ascending
select food