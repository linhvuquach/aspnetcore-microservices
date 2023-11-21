1. Now we can interactive terminal for Mongo

```
- docker run --name shopping-mongo -d mongo:latest
- docker logs -f shopping-mongo
- docker exec -it shopping-mongo mongosh
```

2. After that, we're able to run Mongo commands. Let my try with

- create database
- create collection
- add items into collection
- list collection

```
show dbs
use CatalogDb  --> for create db on mongo
db.createCollection('Products')  --> for create people collection


db.Products.insertMany(
			[
			    {
			        "Name": "Asus Laptop",
			        "Category": "Computers",
			        "Summary": "Summary",
			        "Description": "Description",
			        "ImageFile": "ImageFile",
			        "Price": 54.93
			    },
			    {
			        "Name": "HP Laptop",
			        "Category": "Computers",
			        "Summary": "Summary",
			        "Description": "Description",
			        "ImageFile": "ImageFile",
			        "Price": 88.93
			    }
			])

db.Products.find({}).pretty()
db.Products.remove({})

show databases
show collections
db.Products.find({}).pretty()
```
