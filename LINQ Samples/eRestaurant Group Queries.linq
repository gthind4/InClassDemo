<Query Kind="Expression">
  <Connection>
    <ID>2ecdb854-a1fb-4938-8193-acaa3011a183</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

//grouping
from food in Items
group food by food.MenuCategory.Description

//requires recreation of an anonymous type
from food in Items
group food by new {food.MenuCategory.Description, food.CurrentPrice}


		
	