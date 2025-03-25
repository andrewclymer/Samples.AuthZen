# AuthZen Demo

## Example with additional Subject Properties

{
    "subject":{
        "id":"andy@rocksolidknowledge.com",
        "type":"user",
        "properties":
        {
            "role":["employee"]
        }
    },
    "action":
    {
        "name":"open"
    },
    "resource":
    {
        "type":"door",
        "id":"fireExit"
    },
    "context":
    {
        "buildingIsOnFire":true
    }
}

## Example with Policy Information Point
Requires a PIP to obtain the role information about the user
{
    "subject":{
        "id":"andy@rocksolidknowledge.com",
        "type":"user"
    },
    "action":
    {
        "name":"open"
    },
    "resource":
    {
        "type":"door",
        "id":"fireExit"
    }
}


## Example with Environment Context

{
    "subject":{
        "id":"andy@rocksolidknowledge.com",
        "type":"user"
    },
    "action":
    {
        "name":"open"
    },
    "resource":
    {
        "type":"door",
        "id":"fireExit"
    },
    "context":
    {
        "buildingIsOnFire":true
    }
}
