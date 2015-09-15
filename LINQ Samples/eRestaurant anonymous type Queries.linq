<Query Kind="Expression">
  <Connection>
    <ID>fc3922b5-2878-489c-bf3c-5d3707f013f5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//anonymous type
from food in Items
where food.MenuCategory.Description.Equals("Entree") &&
		food.Active
orderby food.CurrentPrice descending
select new 
		{
			Description=food.Description,
			Price=food.CurrentPrice,
			Cost=food.CurrentCost,
			Profit=food.CurrentPrice-food.CurrentCost
		}	
		
		