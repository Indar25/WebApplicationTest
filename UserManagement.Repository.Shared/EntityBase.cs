namespace UserManagement.Repository.Shared
{
    public abstract class EntityBase<TKey>
       where TKey : IEquatable<TKey>
    {
        public required TKey Id { get; set; }
    }

    public class EntityBase : EntityBase<Guid>
    {
    }
}
