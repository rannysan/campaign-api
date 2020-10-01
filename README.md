# campaign-api

Api developed to manage campaigns.

##### Technologies
  - C#
  - MongoDb
  
    The Nuget package MongoDriver was also used in the API.

# Guide
### Database

  	• Create database:
		○ Run the following command, replacing the <data_directory_path> for C:\Data\db or some other repository of your choice.
			mongod --dbpath <data_directory_path>
		○ After that, open another shell instance and run the command:
			mongo
		○ Run the following command to use or create the bank, if it does not exist:
			use db_campaigns
		○ Run the following command to create the Customers collection:
			db.createCollection('Customers')
		○ Next, we will populate the Customer collection with the following commands:
			db.Customers.insertMany([
				{
					'Name':'Customer 01',
					'Cnpj': '0000000000000000000'
				},
				{
					'Name':'Customer 02',
					'Cnpj': '3333333333333333333'
				}
			])
			
		○ Run the following command to create the Campaigns collection:
			db.createCollection('Campaigns')
		○ Next we will populate the Campaigns collection with the following commands:
			db.Campaigns.insertMany([
				{
					'Name':'Campaign 01',
					'Description': 'New energy drink campaign',
					'Is_active': true,
					'Customer_id': <Adicionar id do customer 01 criado anteriormente>
				},
				{
					'Name':'Campaign 02',
					'Description': 'Old energy drink campaign',
					'Is_active': false,
					'Customer_id': <Adicionar id do customer 01 criado anteriormente>
				},
				{
					'Name':'Campaign 03',
					'Description': 'New shoes campaign',
					'Is_active': true,
					'Customer_id': <Adicionar id do customer 02 criado anteriormente>,
				}
			])
		○ Run the following command to create the Records collection:
			db.createCollection('Records')
		○ Run the following command to create the Users collection:
			db.createCollection('Users')
		○ Run the following command to create the Prizes collection:
			db.createCollection('Prizes')
			
 It is also necessary to run the populate-prizes-script found in the root folder to populate the prizes collection

### How to use the API
###### Main Page

 - To list all active and completed campaigns it is necessary to make a GET request at the address https://localhost:44378/api/campaigns
 - This request returns a list of the following object:
 ````
    {
            "campaignName": "Campaign 03",
            "description": "New sugar campaign",
            "isActive": false,
            "customerId": "5f7240a28064ea990aeee953"
    }
 ````
   ###### Sing Up Pages

-   For the registration form it is necessary to send the object below to the following address, through a POST request, https://localhost:44378/api/users
 ````
{
    "Username": "Carlos",
    "Lastname": "Alberto",
    "Cellnumber": "97979797",
    "Email": "carlos@gmail.com"
}
````
 - To confirm registration for the campaign, it is necessary to send a POST request to  https://localhost:44378/api/records/<campaign_id>/register/<user_id>  `
 
   ###### Campaign Details

-   To receive data with the details of the campaign it is necessary to make a GET request to the address https://localhost:44378/api/campaigns/<campaign_id>
-   The following object will be returned:
 ````
{
        "campaignName": "Campaign 03",
        "description": "New sugar campaign",
        "isActive": false,
        "customerId": "5f7240a28064ea990aeee953"
   }
````
 - To confirm registration for the campaign, it is necessary to send a POST request to  https://localhost:44378/api/records/<campaign_id>/register/<user_id>  
 
   ###### Campaign Details

-   To receive the scoreboard data it is necessary to make a GET request to the following address https://localhost:44378/api/records/<campaign_id> to get the whole rating or https://localhost:44378/api/records/<campaign_id>/top10 to get only the top10.
-   The following object will be returned:
 ````
{
        "id": "id",
        "UserId": "user_id",
        "CampaignId": "campaign_id",
        "UserEntries": 3
   }
````
###### Prize Page

-   To receive the data of the prizes that the user can choose, it is necessary to make a GET request to the following address: https://localhost:44378/api/users/<user_id>/prizes/<campaign_id>
-   The following object will be returned:
 ````
{
        "id": "id",
        "name": "prize1",
        "Wheight": 5,
        "Rarity": 3
   }
````









 
