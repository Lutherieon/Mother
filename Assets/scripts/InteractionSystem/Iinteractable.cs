namespace VHS 
{
    public interface Iinteractable
    {
        public float HoldDuration { get; } 
        bool HoldInteraction { get; }
        bool MultipleUse { get; }
        bool IsInteract { get; }

        void OnInteract();
    }


}
