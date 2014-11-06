[DataStoreConfig( 
    WriteStore =        DataStore.DynamoDB, 
    ReadStoreOrder =    new[] { DataStore.DynamoDB, DataStore.SimpleDB }, 
    WriteRegion =       "us-west-2", 
    ReadRegionOrder =   new[] { "us-west-2", "us-west-1" }
                                                                       )]
public class Player : PlayFabData<Player, UInt64>
{
    [Amazon.DynamoDBv2.DataModel.DynamoDBHashKey]
    public UInt64   UberId { get; set; }
    public string   Email { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastLogin { get; set; }

    static void Sample()
    {
        var player = Player.Get(1234, false);
        player.LastLogin = DateTime.UtcNow;
        player.Update();
    }
}
