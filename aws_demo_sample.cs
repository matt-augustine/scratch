[DataStoreConfig( 
    WriteStore =        DataStore.DynamoDB, 
    ReadStoreOrder =    new[] { DataStore.DynamoDB, DataStore.SimpleDB }, 
    WriteRegion =       "us-west-2", 
    ReadRegionOrder =   new[] { "us-west-2", "us-west-1" }
 )]
public class Player : PlayFabData<Player, UInt64>
{
    [Amazon.DynamoDBv2.DataModel.DynamoDBHashKey]
    public UInt64   UserId    { get; set; }
    public string   Email     { get; set; }
    public DateTime Created   { get; set; }
    public DateTime LastLogin { get; set; }

    static void Sample()
    {
        // Returns the first matching player record, searching
        // DynamoDB and SimpleDB in both regions in the specified order.
        var player = Player.Get(1234, false);
        player.LastLogin = DateTime.UtcNow;
        
        // Updates the player record in the store and 
        // region from which it was loaded.
        player.Update();
        
        // Creates a player record in the default store and region.
        var newPlayer = Player.Create(new Player()
        {
            UserId= 7329,
            Created = DateTime.UtcNow,
        })
    }
}
