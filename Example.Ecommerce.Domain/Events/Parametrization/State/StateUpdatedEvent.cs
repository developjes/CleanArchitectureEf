namespace Example.Ecommerce.Domain.Events.Parametrization.State
{
    public class StateUpdatedEvent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}