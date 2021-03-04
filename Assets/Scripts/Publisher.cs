public class Publisher {
    public delegate void EventHandler();

    public event EventHandler onKill;

    public void CallOnKill() => onKill?.Invoke();
    private static Publisher instance;

    protected Publisher() {
    }

    public static Publisher i {
        get {
            if (instance == null) instance = new Publisher();
            return instance;
        }
    }
}