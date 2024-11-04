namespace Service.Constants;
public static class Messages
{
    public const string TodoAddedMessage = "Task Eklendi";
    public const string TodoUpdatedMessage = "Task Güncellendi";
    public const string TodoDeletedMessage = "Task Silindi.";
    public static string TodoIsNotPresentMessage(Guid id)
    {
        return $"İlgili id ye göre task bulunamadı : {id}";
    }
}
