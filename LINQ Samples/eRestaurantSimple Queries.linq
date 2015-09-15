<Query Kind="Statements">
  <Connection>
    <ID>fc3922b5-2878-489c-bf3c-5d3707f013f5</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//step1 connectb to the desired database
//click on add connection
//take defaults press NEXT
//change server to .(dot), select existing database from drop down list
//optionally press TEST button
//Press OK

//result should show database tables in connection object area
//expanding a table will reveal the table attributes and any relationships.
//remember to check the connection drop down list to see which database  is the active connection.

//view Waiter table data
Waiters;
//QUERY TO ALSO VIEW WAITER TABLE
from item in Waiters
select item;

//method syntax to view Waiter data
//Waiters is the object here and select is the function. The name item is just an input parameter.
Waiters.Select (item => item);

Waiters.Select (item => item.WaiterID==2);

//alter the query syntax into a C# statement
var results= from item in Waiters
   			 select item;
results.Dump();		

public List<pocoObject> SomeBLLMethodName()
{
	//contyent to your DAL object: var context variable
	//do your query
	var results= from item in contextvariable.Waiters
   			 select item;
return results.ToList();	
}