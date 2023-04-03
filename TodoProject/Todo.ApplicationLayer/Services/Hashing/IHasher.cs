namespace Todo.ApplicationLayer.Services.Hashing
{
    public interface IHasher
    {
        string HashString(string data);
    }
}