
public interface IInteractable
{
    string Message { get; }
    bool IsComplete { get; }
    void Interact();
    bool IsActive();
}
