# ASP.NET_Assignment_1 : Key-Value As A Service

## Introduction
With the rise of IoT there is a rise in need of reliable cloud storage. Most IoT projects only need to store key-value pairs. Key-value pair is exactly what it means - an entity with a searchable key and a corresponding value. E.g.: 

{
"key": "temp_dev0",
"value": "87"
}


## Requirement
Create the following public APIs. (Note: All APIs should accept the request and return a response of "application/json" type. Store the key-value in the DATABASE (local or in-memory) for TWO extra points.):

1. GET - "/keys/{key}" - Get key-value pair by key. Return 404 (Not Found) if the key does not exist.
2. POST or PUT - "/keys" - Add a key-value pair. Accept JSON body with the above schema. Return 409 (Conflict code) if the key already exists.
3. PATCH - "/keys/{key}/{value}" - Update the value of the key. Return 404 (Not Found) if the key does not exist.
4. DELETE - "/keys/{key}" - Delete the key-value pair by key. Return 404 (Not Found) if the key does not exist.
