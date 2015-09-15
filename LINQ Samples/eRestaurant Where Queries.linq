<Query Kind="Expression">
  <Connection>
    <ID>fc3922b5-2878-489c-bf3c-5d3707f013f5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//simple where clause
//list all tables that hold more than  3 people
from row in Tables 
where row.Capacity>3 
select row

//list all items with more than 500 calories
from row in Items
where row.Calories>500
select row

//list all items with more than 500 calories and selling for more than $10
from row in Items
where row.Calories>500 && row.CurrentPrice > 10.00m
select row

//list all items with more than 500 calories and are entries on the menu
//HINT: navigational properties of the database and LINQPad knowledge
from foodies in Items
where foodies.Calories>500 && 
	  foodies.MenuCategory.Description.Equals("Entree") 
select foodies