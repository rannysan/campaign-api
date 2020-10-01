namespace CampaignApi.Models
{
    public class CampaignDatabaseSettings : ICampaignDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICampaignDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
