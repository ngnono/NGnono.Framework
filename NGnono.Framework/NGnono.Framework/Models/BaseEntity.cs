namespace NGnono.Framework.Models
{
    [System.Serializable]
    public abstract class BaseEntity
    {
        /// <summary>
        /// KeyMemberId
        /// </summary>
        public abstract object EntityId { get; }
    }
}
