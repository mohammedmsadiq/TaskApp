# TaskApp

What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you’ve used it

I have used prism framework to handle navigation parameters:

var navigationParams = new NavigationParameters();
navigationParams.Add("Id", item.Id);
await this.navigationService.NavigateAsync("AddNewItemPage", navigationParams, false, false);
} 


Please describe yourself using JSON.

{
"FirstName": "Mohammed",
"LastName": "Sadiq",
"nationality": "British",
"livesin": "London",
"Passions": [
"Programming",
"DIY",
"Cars"
],
"Interests": [
"Tech",
"Travelling"
],
"Dreams": [
"To travel around the world“
] 
}

